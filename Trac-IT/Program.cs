using TracIT.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using TracIT;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<TracITDbContext>(builder.Configuration["TracITDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:5169")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Authentication
app.MapGet("/checkuser/{uid}", (TracITDbContext db, string uid) =>
{
    var user = db.Users.Where(us => us.Uid == uid).FirstOrDefault();
    if (uid == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(user);
    }
});

//Create new issue
app.MapPost("/api/issue", (TracITDbContext db, Issue issue, int statusId) =>
{
    db.Issues.Add(issue);
        db.SaveChanges();
    
    
        IssueStatus issueStatusToAdd = new IssueStatus() { statusId = statusId, issueId = issue.issueId };
        db.IssueStatuses.Add(issueStatusToAdd);
        db.SaveChanges();
        
    
    return Results.Created($"/api/issue/{issue.issueId}", issue);
});

//Get all issues
app.MapGet("/api/issue", (TracITDbContext db) =>
{
    return db.Issues.Include(s => s.Issuestatuses.OrderByDescending(o=> o.Id)).ThenInclude(st=> st.status)
    .Include(u => u.IssueUser).ThenInclude(u => u.user)
    .ToList();
    
});

//Get issue by id
app.MapGet("/api/issue/{issueId}", (TracITDbContext db, int issueId) =>
{

    Issue issue = db.Issues.Where(i=> i.issueId == issueId)
    .Include(s=> s.Issuestatuses.OrderByDescending(o=> o.Id)).ThenInclude(st=> st.status)
    .Include(u => u.IssueUser).ThenInclude(u => u.user)
    .FirstOrDefault();
    


    if (issue == null)
    {

        return Results.NotFound();
    }
    return Results.Ok(issue);
});



//Update an issue
app.MapPut("/api/issue/{issueId}", (TracITDbContext db, Issue updatedIssue, int issueId) =>
{
    Issue issue = db.Issues.FirstOrDefault(i => i.issueId == issueId);
    if (issue == null)
    {
        return Results.NotFound();
    }

    issue.title = updatedIssue.title;
    issue.description = updatedIssue.description;
    db.SaveChanges();

    return Results.Ok(issue);
});

//Delete an issue
app.MapDelete("/api/issue/{issueId}", (TracITDbContext db, int issueId) =>
{
    Issue issue = db.Issues.FirstOrDefault(i => i.issueId == issueId);
    if(issue == null)
    {
        return Results.NotFound();
    }
    db.Issues.Remove(issue); db.SaveChanges(); return Results.Ok(issue);
});

//Create a new user
app.MapPost("/api/user", (TracITDbContext db, User user) =>
{
    object value = db.Users.Add(user);
    db.SaveChanges();
});

//Get a single user
app.MapGet("/api/user/{id}", (TracITDbContext db, int Id) =>
{
    User user = db.Users.FirstOrDefault(user => user.userId == Id);
    if (user == null)
    {
        return Results.NotFound();
    }
    return Results.Ok();
});

//Get all users
app.MapGet("/api/user", (TracITDbContext db) =>
{
     return db.Users.ToList();
});



//Create a comment
app.MapPost("/api/comment", (TracITDbContext db, Comment comment) =>
{
    db.Comments.Add(comment);
    db.SaveChanges();
});

// Get Status by Id
app.MapGet("/api/status/{statusId}", (TracITDbContext db, int statusId) =>
{
    Status status = db.Status.FirstOrDefault(s => s.statusId == statusId);
    if (status == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(status);
});

//});

//Update issuestatus
app.MapPost("/api/issueStatus", (TracITDbContext db, IssueStatus issueStatus) =>
{
    db.IssueStatuses.Add(issueStatus);
    db.SaveChanges();
});

//Add/Update issueuser
app.MapPost("/api/issueUser/{issueId}", (TracITDbContext db, List<IssueUser>  issueUser, int issueId) =>
{
   List<IssueUser> issueUsers = db.IssueUser.Where(x => x.issueId == issueId).ToList();
    if (issueUsers.Count()!=0 )
    {
        db.IssueUser.RemoveRange(issueUsers);

    }
    db.IssueUser.AddRange(issueUser);
    db.SaveChanges();
});








app.Run();

