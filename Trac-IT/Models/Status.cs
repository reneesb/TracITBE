using System.ComponentModel.DataAnnotations;

namespace TracIT.Models
{
    public class Status
    {
        [Key]
        public int statusId { get; set; }
        public string statusName { get; set; }
        public List<IssueStatus> Issuestatuses { get; set; }

    }
}
