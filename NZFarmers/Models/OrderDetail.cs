using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }  // Unique identifier for the order detail.

        [Required(ErrorMessage = "Order is required.")]
        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }  // Navigation property linking to the Order.

        [Required(ErrorMessage = "Farmer product is required.")]
        [ForeignKey(nameof(FarmerProduct))]
        public int FarmerProductID { get; set; }
        public virtual FarmerProduct FarmerProduct { get; set; }  // Navigation property linking to the FarmerProduct.

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; }  // The quantity of the product ordered.

        [Required(ErrorMessage = "Subtotal is required.")]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000000.00, ErrorMessage = "Subtotal must be between $0.01 and $1,000,000.")]
        public decimal Subtotal { get; set; }  // The financial subtotal for this detail line.
    }
}
