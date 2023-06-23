using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Trader:Account
    {
        public int Id { get; set; }

        public string StoreName { get; set; } // we will add governement and city --> Mostafa   

        public int SpecialPickupCost { get; set; }

        public int TraderTaxForRejectedOrders { get; set; }

        //City and govern,branch prop created by salah && rizk 

        [ForeignKey("Government")]
        public int GoverId { get; set; }
        public virtual Government? Governorate { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public virtual Branch? Branch { get; set; }
<<<<<<< HEAD
        public string Role { get; set; } = "Trader";
=======


       public List<TraderSpecialPriceForCities>? SpecialPriceForCities { get; set; } =
                            new List<TraderSpecialPriceForCities>();
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
