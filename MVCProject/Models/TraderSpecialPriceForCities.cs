using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class TraderSpecialPriceForCities
    {
        public int Id { get; set; }

        // Government 
        public int Shippingprice { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Trader")]
        public int TraderId { get; set; }
        public Trader? Trader { get; set; }


        //City prop created by salah && rizk
        [ForeignKey ("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }

    }
}
