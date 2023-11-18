using Microsoft.EntityFrameworkCore;
using TracIT.Models;

namespace TracIT
{
    public class TracITDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Status> Status { get; set; }

        public TracITDbContext(DbContextOptions<TracITDbContext> context) : base(context) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>().HasData(new Issue[]
            {
                new Issue {issueId = 1, title = "Create Modal", description = "Create modal for entering new issue"},
            });
            modelBuilder.Entity<Status>().HasData(new Status[]
            {
                new Status {statusId = 1, statusName = "New"},
                new Status {statusId = 2, statusName = "Active"},
                new Status {statusId = 3, statusName = "Closed"}
            });
        }
    }

    
}
