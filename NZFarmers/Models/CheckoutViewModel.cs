using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NZFarmers.Models; // Reference to the Models namespace where related classes (like PaymentMethod) live

namespace NZFarmers.ViewModels
{
    // This class should not be mapped to the database. It’s only used for data transfer (ViewModel).
    [NotMapped]
    public class CheckoutViewModel
    {
        // List of items the user has in their shopping cart to review before checkout.
        public List<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();

        // The address where the order will be shipped.
        [Required(ErrorMessage = "Shipping address is required.")]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = string.Empty;

        // The city field required for shipping.
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        // Region or state (used for localizing within NZ).
        [Required(ErrorMessage = "Region is required.")]
        public string Region { get; set; } = string.Empty;

        // Postal or zip code for the shipping destination.
        [Required(ErrorMessage = "Zip code is required.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } = string.Empty;

        // The selected payment method (e.g., Credit Card, Stripe, PayPal).
        [Required(ErrorMessage = "Please choose a payment method.")]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
