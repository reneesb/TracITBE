using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace TracIT.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string Uid { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userRole { get; set; }
        public string imageUrl { get; set; }
        

        
    }
}
