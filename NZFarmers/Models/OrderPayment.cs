using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    public class OrderPayment
    {

        [Key]
        public int OrderPaymentID { get; set; }  // Unique identifier

        [Required(ErrorMessage = "Order is required.")]
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; } = default!;

        [Required(ErrorMessage = "Payment is required.")]
        public int PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual PaymentDetail PaymentDetail { get; set; } = default!;

    }
}
