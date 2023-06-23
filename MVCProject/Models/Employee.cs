using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Employee:Account
    {

        public int Id { get; set; }
        public string Role { get; set; }


    }
}
