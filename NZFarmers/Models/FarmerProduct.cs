// Required for data annotations and validation attributes
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    // Enum for product categories to ensure controlled values
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

    // Represents a product listed by a farmer
    public class FarmerProduct
    {
        // Primary key for each product
        [Key]
        public int FarmerProductID { get; set; }

        // Foreign key referencing the associated farmer
        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }

        // Navigation property to the Farmer who owns the product
        [ForeignKey(nameof(FarmerID))]
        public virtual Farmers Farmer { get; set; } = default!;

        // Name of the product, must be 2 to 100 characters long
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name must be between 2 and 100 characters.", MinimumLength = 2)]
        public string ProductName { get; set; } = string.Empty;

        // Optional description of the product, up to 500 characters
        [StringLength(500, ErrorMessage = "Product description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        // Category selected from the ProductCategory enum
        [Required(ErrorMessage = "Category is required.")]
        public ProductCategory Category { get; set; } = ProductCategory.Other;

        // Price of the product, must be between $0.01 and $10,000
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between $0.01 and $10,000.")]
        public decimal Price { get; set; }

        // Stock level for the product, must be a non-negative number
        [Required(ErrorMessage = "Stock level is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative.")]
        public int Stock { get; set; }

        // URL pointing to the product's image
        [Url(ErrorMessage = "Invalid URL for image.")]
        public string? ImageURL { get; set; }

        // File upload for the image; not stored in the DB
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        // One-to-many relationship: a product can be in many cart items
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

        // One-to-many relationship: a product can appear in many order details
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    }
}
