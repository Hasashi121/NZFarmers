// Required namespaces for data annotations and database relationships
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    // Enumeration to define the current delivery state of an order
    public enum DeliveryStatus
    {
        Preparing,   // The order is being prepared
        Shipped,     // The order has been shipped
        Delivered,   // The order has been delivered to the customer
        Cancelled    // The order was cancelled
    }

    // This class represents delivery tracking information for an order
    public class DeliveryTracking
    {
        // Primary key for tracking delivery progress
        [Key]
        public int TrackingID { get; set; }

        // Foreign key reference to the associated order
        [Required(ErrorMessage = "Order is required.")]
        public int OrderID { get; set; }

        // Establishes a relationship between DeliveryTracking and Order
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = default!;

        // The current status of the delivery, default is 'Preparing'
        [Required(ErrorMessage = "Delivery status is required.")]
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Preparing;

        // The last time this record was updated, defaulting to now in UTC
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
