using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    //this model craeted br salah & rizk not emplemented

    public class Government
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Governorate name must be less than 20 char")]
        [MinLength(3, ErrorMessage = "Governorate name must be more than 5 char")]
        public string Name { get; set; }
<<<<<<< HEAD:MVCProject/Models/Governorate.cs
        public List<City> City { get; set; }=new List<City>();
        public List<Trader> Traders { get; set; }


=======
        public List<City> Cities { get; set; }=new List<City>();
        public List<Trader> Traders { get; set; }
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00:MVCProject/Models/Government.cs
    }
}
