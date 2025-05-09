using System.ComponentModel.DataAnnotations;         // For validation attributes
using System.ComponentModel.DataAnnotations.Schema;  // For [ForeignKey] and database mapping

namespace NZFarmers.Models
{
    // This class represents the details of a single product in an order
    public class OrderDetail
    {
        // Primary key for the OrderDetail table
        [Key]
        public int OrderDetailID { get; set; }

        // Foreign key linking this detail to the parent order
        [Required(ErrorMessage = "Order is required.")]
        public int OrderID { get; set; }

        // Navigation property to the related Order
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = default!;

        // Foreign key linking to the purchased farmer product
        [Required(ErrorMessage = "Farmer product is required.")]
        public int FarmerProductID { get; set; }

        // Navigation property to the related FarmerProduct
        [ForeignKey(nameof(FarmerProductID))]
        public virtual FarmerProduct FarmerProduct { get; set; } = default!;

        // Number of units of this product in the order
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 500, ErrorMessage = "Quantity must be between 1 and 500.")]
        public int Quantity { get; set; }

        // Calculated total price for this item (Price × Quantity)
        [Required(ErrorMessage = "Subtotal is required.")]
        [Range(0.01, 1000000.00, ErrorMessage = "Subtotal must be between $0.01 and $1,000,000.")]
        public decimal Subtotal { get; set; }
    }
}
