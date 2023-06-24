using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Branch
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "Name must be more than 3 char")]
        public string Name { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
        public List<Trader> Traders { get; set; }
    }
}
