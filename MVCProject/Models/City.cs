using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class City
    {
        
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Governorate name must be less than 20 char")]
        [MinLength(3, ErrorMessage = "Governorate name must be more than 5 char")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter shipping cost")]
        public decimal ShippingCost { get; set; }
        [ForeignKey ("Governorate") ]
        public int GoverId { get; set; }
<<<<<<< HEAD
        public virtual Governorate? Governorate { get; set; }
        public List<Trader> Traders { get; set; }

=======
        public virtual Government? Governorate { get; set; }

        public List<Trader> Traders { get; set; }
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00






    }
}
