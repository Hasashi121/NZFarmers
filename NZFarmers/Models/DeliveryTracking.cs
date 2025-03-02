using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class DeliveryTracking
    {
        [Key]
        public int TrackingID { get; set; }

        [Required(ErrorMessage = "Order association is mandatory.")]
        public int OrderID { get; set; } // This is the actual foreign key property

        [ForeignKey("OrderID")] // This should reference the name of the foreign key property
        public virtual Order Order { get; set; }

        [Required(ErrorMessage = "Delivery status is required.")]
        [StringLength(50, ErrorMessage = "Delivery status description cannot exceed 50 characters.")]
        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
