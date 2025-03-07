using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(200, ErrorMessage = "Product name cannot exceed 200 characters.")]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Product description is too long.")]
        public string? Description { get; set; }

        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; } = new List<FarmerProduct>();
    }
}
