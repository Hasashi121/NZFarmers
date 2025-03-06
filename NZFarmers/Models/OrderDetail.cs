using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        [Required(ErrorMessage = "Order is required.")]
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = default!;

        [Required(ErrorMessage = "Farmer product is required.")]
        public int FarmerProductID { get; set; }
        [ForeignKey(nameof(FarmerProductID))]
        public virtual FarmerProduct FarmerProduct { get; set; } = default!;

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Subtotal is required.")]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000000.00, ErrorMessage = "Subtotal must be between $0.01 and $1,000,000.")]
        public decimal Subtotal { get; set; }
    }
}
