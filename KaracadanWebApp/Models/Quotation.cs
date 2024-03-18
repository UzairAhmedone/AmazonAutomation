using System.ComponentModel.DataAnnotations;

namespace KaracadanWebApp.Models
{
    public class Quotation: BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string? RefNo { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Quantity Required")]
        public double? Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice Required")]
        public double? UnitPrice { get;set;}

        [Required(ErrorMessage = "TotalPrice Required")]
        public double? TotalPrice { get; set; } 


    }
}
