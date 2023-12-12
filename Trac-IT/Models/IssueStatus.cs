using System.ComponentModel.DataAnnotations;

namespace TracIT.Models
{
    public class IssueStatus
    {
        [Key] public int Id { get; set; }
        public int issueId {  get; set; }
        public int statusId { get; set; }
        public Issue issue { get; set; }
        public Status status { get; set; }
    }
}
