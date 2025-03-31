using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NZFarmers.Areas.Identity.Data;

namespace NZFarmers.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemID { get; set; }

        [Required]
        public string UserID { get; set; } = string.Empty;
        [ForeignKey(nameof(UserID))]
        public virtual NZFarmersUser User { get; set; } = default!;

        [Required]
        public int FarmerProductID { get; set; }
        [ForeignKey(nameof(FarmerProductID))]
        public virtual FarmerProduct FarmerProduct { get; set; } = default!;

        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; } = 1;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
