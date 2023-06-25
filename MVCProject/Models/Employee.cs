using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Employee:Account
    {

        public int Id { get; set; }
        public string Role { get; set; }

        [ForeignKey("Branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
    }
}
