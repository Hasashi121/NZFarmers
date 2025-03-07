using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NZFarmers.Areas.Identity.Data;

namespace NZFarmers.Models
{
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
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Customer association is required.")]
        public string UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual NZFarmersUser User { get; set; } = default!;

        [Required(ErrorMessage = "Total price is required.")]
        [Range(0.01, 1000000.00, ErrorMessage = "Total price must be between $0.01 and $1,000,000.")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual DeliveryTracking? DeliveryTracking { get; set; }
    }
}
