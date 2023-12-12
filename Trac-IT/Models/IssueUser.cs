using System.ComponentModel.DataAnnotations;

namespace TracIT.Models
{
    public class IssueUser

    {
        [Key]
        public int Id { get; set; }
        public int issueId { get; set; }
        public int userId { get; set; }
        public Issue issue { get; set; }
        public User user { get; set; }
    }
}
