using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NZFarmers.Models;



namespace NZFarmers.ViewModels
{
    [NotMapped]
    public class CheckoutViewModel
    {
        // The cart items for review.
        public List<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();

        // Shipping details.
        [Required(ErrorMessage = "Shipping address is required.")]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Region is required.")]
        public string Region { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip code is required.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } = string.Empty;

        // Payment method chosen by the user.
        [Required(ErrorMessage = "Please choose a payment method.")]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
