using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel
{
    public class EmployeeBranchPermissionsViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
