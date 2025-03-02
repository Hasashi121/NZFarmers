using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class FarmerProduct
    {
        [Key]
        public int FarmerProductID { get; set; }

        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }

        [ForeignKey(nameof(FarmerID))]  // Correctly reference the foreign key property
        public virtual Farmers Farmer { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        public int ProductID { get; set; }

        [ForeignKey(nameof(ProductID))]  // Correctly reference the foreign key property
        public virtual Products Product { get; set; }

        [Required(ErrorMessage = "Price must be specified.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between $0.01 and $10,000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock level is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer.")]
        public int Stock { get; set; }

        [Url(ErrorMessage = "Invalid URL for image.")]
        public string? ImageURL { get; set; }

        // Navigation property for order details referencing this farmer's product.
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
