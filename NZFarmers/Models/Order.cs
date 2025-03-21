using NZFarmers.Areas.Identity.Data;
using NZFarmers.Models;
using System.ComponentModel.DataAnnotations.Schema;

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public class Order
{
    public int OrderID { get; set; }

    // Foreign key to Identity user in AspNetUsers
    public string UserID { get; set; } = string.Empty;

    // Navigation to Identity user
    [ForeignKey(nameof(UserID))]
    public virtual NZFarmersUser User { get; set; } = default!;

    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual DeliveryTracking? DeliveryTracking { get; set; }
}
