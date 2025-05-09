using System;                                   
using System.ComponentModel.DataAnnotations;      
using System.ComponentModel.DataAnnotations.Schema; 
using NZFarmers.Areas.Identity.Data;               

namespace NZFarmers.Models
{
    // Represents an item that a user has added to their shopping cart
    public class ShoppingCartItem
    {
        // Primary key for the shopping cart item
        [Key]
        public int ShoppingCartItemID { get; set; }

        // Foreign key: the ID of the user who owns this cart item
        [Required]
        public string UserID { get; set; } = string.Empty;

        // Navigation property to the associated user
        [ForeignKey(nameof(UserID))]
        public virtual NZFarmersUser User { get; set; } = default!;

        // Foreign key: the ID of the farmer product added to the cart
        [Required]
        public int FarmerProductID { get; set; }

        // Navigation property to the farmer product
        [ForeignKey(nameof(FarmerProductID))]
        public virtual FarmerProduct FarmerProduct { get; set; } = default!;

        // Quantity of the product added to the cart (1–1000 allowed)
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
        public int Quantity { get; set; } = 1;

        // Timestamp for when this item was added to the cart
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
