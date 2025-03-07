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

        [Required(ErrorMessage = "Product is required.")]
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public virtual Products Product { get; set; } = default!;

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

        // Navigation for OrderDetail
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
