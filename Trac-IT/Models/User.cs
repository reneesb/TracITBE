using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace TracIT.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Uid { get; set; }
        public string userName { get; set; }
        
    }
}
