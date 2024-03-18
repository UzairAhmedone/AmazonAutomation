using Microsoft.AspNetCore.Identity;
namespace KaracadanWebApp.Models
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public long? CreatedBy { get; set; }
}
}
