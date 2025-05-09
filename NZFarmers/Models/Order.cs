using NZFarmers.Areas.Identity.Data; // Namespace for accessing Identity users
using NZFarmers.Models; // Access to related models like OrderDetail and DeliveryTracking
using System.ComponentModel.DataAnnotations.Schema; // For mapping relationships

// Enum representing various stages an order can go through
public enum OrderStatus
{
    Pending,      // Order placed but not yet processed
    Processing,   // Order is being handled/prepared
    Shipped,      // Order has been dispatched
    Delivered,    // Order has been received by the customer
    Cancelled     // Order has been cancelled
}

// Represents a customer's order
public class Order
{
    // Primary Key for the Order table
    public int OrderID { get; set; }

    // Foreign Key that links to the user who placed the order
    public string UserID { get; set; } = string.Empty;

    // Navigation property to access the related NZFarmersUser from Identity
    [ForeignKey(nameof(UserID))]
    public virtual NZFarmersUser User { get; set; } = default!;

    // Total price of the order calculated from individual order items
    public decimal TotalPrice { get; set; }

    // Current status of the order (uses the OrderStatus enum)
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    // Timestamp of when the order was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Collection of OrderDetail items related to this order
    public virtual ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();

    // Optional: Each order can have a delivery tracking record
    public virtual DeliveryTracking? DeliveryTracking { get; set; }
}
