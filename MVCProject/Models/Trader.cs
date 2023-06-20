using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Trader
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "ame must be less than 50 char")] //add err mess by salah && rizk
        [MinLength(3, ErrorMessage = "Name must be more than 3 char")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,16})$",
        ErrorMessage = "Password must be 8-16 characters long</br> with at least one numeric character")]
        public string Password { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please Enter Valid Phone Number")]
        public string Phone { get; set; }
        public string Address { get; set; }

        public string StoreName { get; set; } // we will add governement and city --> Mostafa   

        public int SpecialPickupCost { get; set; }

        public int TraderTaxForRejectedOrders { get; set; }

        //City and govern,branch prop created by salah && rizk 

        [ForeignKey("Governorate")]
        public int GoverId { get; set; }
        public virtual Governorate? Governorate { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }



    }
}
