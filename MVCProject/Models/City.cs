﻿using System.ComponentModel.DataAnnotations;
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
        public virtual Governorate? Governorate { get; set; }
        public List<Trader> Traders { get; set; }







    }
}
