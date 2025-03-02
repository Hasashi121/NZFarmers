using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }  // Unique order identifier

        [Required(ErrorMessage = "Customer association is mandatory.")]
        public int UserID { get; set; }   // Foreign key property

        [ForeignKey(nameof(UserID))]   // Correctly references the foreign key property name
        public virtual User User { get; set; }  // Navigation property linking to the User

        [Required(ErrorMessage = "Total price is required.")]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000000.00, ErrorMessage = "Total price must be between $0.01 and $1,000,000.")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        [StringLength(50, ErrorMessage = "Order status cannot exceed 50 characters.")]
        public string Status { get; set; }  // e.g., Pending, Processing, Completed, Cancelled

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderPayment> OrderPayments { get; set; }
        public virtual DeliveryTracking? DeliveryTracking { get; set; }

    }
}
