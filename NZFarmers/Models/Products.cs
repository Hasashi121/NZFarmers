using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(255, ErrorMessage = "Product name cannot exceed 255 characters.")]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Product description is too long.")]
        public string? Description { get; set; }

        // Navigation: Many farmers can list this product
        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; } = new List<FarmerProduct>();
    }
}
