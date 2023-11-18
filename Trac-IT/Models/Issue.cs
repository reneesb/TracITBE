using System.ComponentModel.DataAnnotations;

namespace TracIT.Models
{
    public class Issue
    {
        [Key]
        public int issueId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
       
        public DateTime dateTimeCreated => DateTime.Now;
    }
}
