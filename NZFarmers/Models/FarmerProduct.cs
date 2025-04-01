using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    public enum ProductCategory
    {
        Vegetables,
        Fruits,
        Seeds,
        Dairy,
        Meat,
        Grains,
        Other
    }

    public class FarmerProduct
    {
        [Key]
        public int FarmerProductID { get; set; }

        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }

        [ForeignKey(nameof(FarmerID))]
        public virtual Farmers Farmer { get; set; } = default!;

        // Removed dependency on the Products model.
        // Instead, include product-specific details directly:

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name must be between 2 and 100 characters.", MinimumLength = 2)]
        public string ProductName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Product description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public ProductCategory Category { get; set; } = ProductCategory.Other;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between $0.01 and $10,000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock level is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative.")]
        public int Stock { get; set; }

        [Url(ErrorMessage = "Invalid URL for image.")]
        public string? ImageURL { get; set; }

        // Property for file upload (not mapped to the database)
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        // Navigation property for OrderDetail
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
