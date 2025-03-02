using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(255, ErrorMessage = "Product name cannot exceed 255 characters.")]
        public string ProductName { get; set; }

        [StringLength(2000, ErrorMessage = "Product description is too long.")]
        public string? Description { get; set; }

        // Navigation property: Many farmers can offer this product.
        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; }
    }
}
