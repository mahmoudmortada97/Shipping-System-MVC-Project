using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel
{
    public class AccountViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,16})$",
                    ErrorMessage = "Password must be 8-16 characters long</br> with at least one numeric character")]
        public string Password { get; set; }

        [Required]
        public string LoginType { get; set; }
    }
    public enum LoginType
    {
        Employee,
        Trader,
        Representative
    }
}
