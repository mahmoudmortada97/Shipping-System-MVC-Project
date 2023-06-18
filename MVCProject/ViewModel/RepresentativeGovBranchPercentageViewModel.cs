﻿using MVCProject.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel
{
    public class RepresentativeGovBranchPercentageViewModel
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

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "The Phone number field is not valid")]
        public string Phone { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string Address { get; set; }

        public decimal CompanyPercentageOfOrder { get; set; }

        [Required(ErrorMessage = "Please choose governorate")]
        public int GovernorateId { get; set; }
        public  List<Governorate> Governorates { get; set; } //for drop down list

        [Required(ErrorMessage = "Please choose branch")]
        public int BranchId { get; set; }
        public List<Branch> Branchs { get; set; } //for drop down list
        public int? DiscountTypeId { get; set; }
        public List<DiscountType> DiscountTypes { get; set; } //for drop down list
    }
}