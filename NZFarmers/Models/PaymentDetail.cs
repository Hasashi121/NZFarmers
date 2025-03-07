using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NZFarmers.Areas.Identity.Data;

namespace NZFarmers.Models
{
    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        PayPal,
        BankTransfer
    }

    public class PaymentDetail
    {
        [Key]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "User association is required.")]
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual NZFarmersUser User { get; set; } = default!;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 1000000.00, ErrorMessage = "Amount must be between $0.01 and $1,000,000.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment status is required.")]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        [Required(ErrorMessage = "Payment method is required.")]
        public PaymentMethod Method { get; set; } = PaymentMethod.CreditCard;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Order>? Orders { get; set; } = new List<Order>();
    }
}
