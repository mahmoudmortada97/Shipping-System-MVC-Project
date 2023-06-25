using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Trader:Account
    {
        public int Id { get; set; }

        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        [Display(Name = "Special Pickup Cost")]
        public int SpecialPickupCost { get; set; }

        [Display(Name = "Trader Tax For Rejected Orders")]
        public int TraderTaxForRejectedOrders { get; set; }

        [Display(Name = "Governorate")]
        [ForeignKey("Governorate")]
        [Required(ErrorMessage = "Please select governorate")]
        public int? GoverId { get; set; }
        public virtual Governorate Governorate { get; set; }

        [Display(Name = "City")]
        [ForeignKey("City")]
        [Required(ErrorMessage = "Please select city")]
        public int? CityId { get; set; }
        public virtual City City { get; set; }

        [Display(Name = "Branch")]
        [ForeignKey("Branch")]
        [Required(ErrorMessage = "Please select branch")]
        public int? BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public string Role { get; set; } = "Trader";


       public List<TraderSpecialPriceForCities>? SpecialPriceForCities { get; set; } =
                            new List<TraderSpecialPriceForCities>();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
