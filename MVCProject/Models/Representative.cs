using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Representative:Account
    {
        [Key]
        public int Id { get; set; }

        public decimal CompanyPercentageOfOrder { get; set; }

        [ForeignKey("Governorate")]
        public int GovernorateId { get; set; }
        public virtual Government? Governorate { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

        [ForeignKey("DiscountType")]
        public int? DiscountTypeId { get; set; } 
        public DiscountType? DiscountType { get; set; }

    }
}
