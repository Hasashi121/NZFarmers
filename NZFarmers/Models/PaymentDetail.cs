using System.ComponentModel.DataAnnotations;         // Provides validation attributes
using System.ComponentModel.DataAnnotations.Schema;  // Provides schema mapping features like [Key], [ForeignKey]
using NZFarmers.Areas.Identity.Data;                 // Imports custom identity user model (NZFarmersUser)

namespace NZFarmers.Models
{
    // Enum representing possible statuses a payment can have
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    // Enum representing payment method options
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        PayPal,
        BankTransfer
    }

    // Main PaymentDetail class for storing payment transaction information
    public class PaymentDetail
    {
        // Primary key for the payment record
        [Key]
        public int PaymentID { get; set; }

        // Required foreign key linking to a registered user
        [Required(ErrorMessage = "User association is required.")]
        public string UserID { get; set; } = string.Empty;

        // Navigation property to the NZFarmersUser who made the payment
        [ForeignKey(nameof(UserID))]
        public virtual NZFarmersUser User { get; set; } = default!;

        // The total amount paid
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 1000000.00, ErrorMessage = "Amount must be between $0.01 and $1,000,000.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        // The status of the payment (Pending, Completed, etc.)
        [Required(ErrorMessage = "Payment status is required.")]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        // The selected method used to make the payment
        [Required(ErrorMessage = "Payment method is required.")]
        public PaymentMethod Method { get; set; } = PaymentMethod.CreditCard;

        // Timestamp when the payment record was created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Required foreign key to link the payment to an order
        [Required(ErrorMessage = "Order is required.")]
        public int OrderID { get; set; }

        // Navigation property to the related Order
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = default!;
    }
}
