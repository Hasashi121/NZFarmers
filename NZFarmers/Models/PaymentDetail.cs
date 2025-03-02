using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentID { get; set; }  // Unique identifier

        [Required(ErrorMessage = "User association is mandatory.")]
        public int UserID { get; set; }  // Foreign key property

        [ForeignKey(nameof(UserID))]  // Correctly references the foreign key property
        public virtual User User { get; set; }  // Navigation property linking to User

        [Required(ErrorMessage = "Amount is required.")]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000000.00, ErrorMessage = "Amount must be between $0.01 and $1,000,000.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment status is required.")]
        [StringLength(50, ErrorMessage = "Payment status cannot exceed 50 characters.")]
        public string Status { get; set; }  // e.g., Pending, Completed, Failed

        [Required(ErrorMessage = "Payment method is required.")]
        [StringLength(50, ErrorMessage = "Payment method description cannot exceed 50 characters.")]
        public string PaymentMethod { get; set; }  // e.g., Card, Bank Transfer

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for linking payments with orders
        public virtual ICollection<OrderPayment> OrderPayments { get; set; }

    }
}
