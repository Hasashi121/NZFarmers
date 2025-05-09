using System.ComponentModel.DataAnnotations; // For validation attributes
using System.ComponentModel.DataAnnotations.Schema; // For database mapping
using NZFarmers.Areas.Identity.Data; // To link with ASP.NET Identity user

namespace NZFarmers.Models
{
    // This class represents a Farmer entity in the system
    public class Farmers
    {
        // Primary Key for the Farmers table
        [Key]
        public int FarmerID { get; set; }

        // Foreign Key: links to the ASP.NET Identity user
        [Required(ErrorMessage = "User association is required.")]
        public string UserID { get; set; } = string.Empty;

        // Navigation property to access the related Identity User
        [ForeignKey(nameof(UserID))]
        public virtual NZFarmersUser User { get; set; } = default!;

        // Required: Name of the farm
        [Required(ErrorMessage = "Farm name is required.")]
        [StringLength(255, ErrorMessage = "Farm name cannot exceed 255 characters.")]
        public string FarmName { get; set; } = string.Empty;

        // Optional: A description about the farmer or their farm
        [StringLength(1000, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        // Required: Farmer's phone number, validated using NZ format
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^(\+64|0)[2-9]\d{7,9}$", ErrorMessage = "Must be a valid New Zealand phone number. +64xxxxxxx")]
        public string PhoneNumber { get; set; } = string.Empty;

        // Optional: URL to the farmer's profile image
        [Url(ErrorMessage = "Invalid URL for profile image.")]
        public string? ProfileImage { get; set; }

        // File upload object for profile image (excluded from DB)
        [NotMapped]
        public IFormFile? ProfileImageFile { get; set; }

        // Required: Physical address of the farm
        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string Address { get; set; } = string.Empty;

        // Required: City where the farm is located
        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        public string City { get; set; } = string.Empty;

        // Required: Region the farm belongs to
        [Required(ErrorMessage = "Region is required.")]
        [StringLength(100, ErrorMessage = "Region cannot exceed 100 characters.")]
        public string Region { get; set; } = string.Empty;

        // Optional: Postal zip code for the farm's location
        [StringLength(10, ErrorMessage = "Zip code cannot exceed 10 characters.")]
        public string? ZipCode { get; set; }

        // A farmer can list multiple products
        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; } = new List<FarmerProduct>();

        // A farmer can receive multiple ratings
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        // A farmer can participate in multiple farmer market events
        public virtual ICollection<FarmerMarketParticipation> FarmerMarketParticipations { get; set; } = new List<FarmerMarketParticipation>();
    }
}
