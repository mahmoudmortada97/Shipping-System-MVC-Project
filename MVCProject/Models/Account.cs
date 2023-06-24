using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Account
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,16})$",
                    ErrorMessage = "Password must be 8-16 characters long</br> with at least one numeric character")]
        
        public string Password { get; set; }
        
        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "FullName must be more than 2 char")] //Edited from 8 char --> 3 -- please don't edit it again
        public string Name { get; set; }

        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please Enter Valid Phone Number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime creationDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsDeleted { get; set; } = false;

    }
}
