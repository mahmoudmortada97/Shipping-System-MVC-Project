using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Representative
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(8, ErrorMessage = "Name must be more than 8 char")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,16})$",
                    ErrorMessage = "Password must be 8-16 characters long</br> with at least one numeric character")]
        public string Password { get; set; }

        public bool IsDeleted { get; set; } = false;

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please Enter Valid Phone Number")]
        public string Phone { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string Address { get; set; }

        public decimal CompanyPercentageOfOrder { get; set; }

        [ForeignKey("Governorate")]
        public int GovernorateId { get; set; }
        public virtual Governorate? Governorate { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }

        [ForeignKey("DiscountType")]
        public int? DiscountTypeId { get; set; } 
        public DiscountType? DiscountType { get; set; }

    }
}
