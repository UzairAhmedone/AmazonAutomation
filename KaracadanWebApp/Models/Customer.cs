using System.ComponentModel.DataAnnotations;

namespace KaracadanWebApp.Models
{
    public class Customer : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string? Name { get; set; }

        [StringLength(100, ErrorMessage = "Email must be 100")]
        [EmailAddress(ErrorMessage = "Email formate Incorrect")]
        [Required(ErrorMessage = "Email required")]
        public string? Email { get; set; }
        public long? PhoneNo { get; set; }    
        public string? Address { get; set; } 
    }
}
