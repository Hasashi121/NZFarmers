using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    public enum DeliveryStatus
    {
        Preparing,
        Shipped,
        Delivered,
        Cancelled
    }

    public class DeliveryTracking
    {
        [Key]
        public int TrackingID { get; set; }

        [Required(ErrorMessage = "Order is required.")]
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = default!;

        [Required(ErrorMessage = "Delivery status is required.")]
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Preparing;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
