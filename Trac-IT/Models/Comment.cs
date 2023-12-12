using System.ComponentModel.DataAnnotations;

namespace TracIT.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }
        public string commentText { get; set; }
        public User user { get; set; }
        public Issue issue { get; set; }

    }
}
