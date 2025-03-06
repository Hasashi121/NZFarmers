using Microsoft.AspNetCore.Identity;
using NZFarmers.Models;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Areas.Identity.Data
{
    public enum RoleType
    {
        Admin,
        Farmer,
        Consumer
    }

    public class NZFarmersUser : IdentityUser
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "First name must start with an uppercase letter.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Last name must start with an uppercase letter.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "User role is required.")]
        public RoleType Role { get; set; } = RoleType.Consumer;

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits.")]
        public string ContactNumber { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
