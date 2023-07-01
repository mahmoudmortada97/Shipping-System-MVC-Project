﻿using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    //this model craeted br salah & rizk not emplemented

    public class Governorate
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "Governorate name must be less than 20 char")]
        [MinLength(3, ErrorMessage = "Governorate name must be more than 3char")]
        public string Name { get; set; }
        public List<Trader> Traders { get; set; }=new List<Trader>();   

        public List<City> Cities { get; set; }=new List<City>();

        public bool IsDeleted { get; set; }
    }
}
