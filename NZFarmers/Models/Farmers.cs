using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NZFarmers.Areas.Identity.Data;

namespace NZFarmers.Models
{
    public class Farmers
    {
        [Key]
        public int FarmerID { get; set; }

        [Required(ErrorMessage = "User association is required.")]
        public string UserID { get; set; } = string.Empty;
        [ForeignKey(nameof(UserID))]
        public virtual NZFarmersUser User { get; set; } = default!;

        [Required(ErrorMessage = "Farm name is required.")]
        [StringLength(255, ErrorMessage = "Farm name cannot exceed 255 characters.")]
        public string FarmName { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^(\+64|0)[2-9]\d{7,9}$", ErrorMessage = "Must be a valid New Zealand phone number. +64xxxxxxx")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Url(ErrorMessage = "Invalid URL for profile image.")]
        public string? ProfileImage { get; set; }

        // For file uploads (not stored in DB)
        [NotMapped]
        public IFormFile? ProfileImageFile { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Region is required.")]
        [StringLength(100, ErrorMessage = "Region cannot exceed 100 characters.")]
        public string Region { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "Zip code cannot exceed 10 characters.")]
        public string? ZipCode { get; set; }

        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; } = new List<FarmerProduct>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<FarmerMarketParticipation> FarmerMarketParticipations { get; set; } = new List<FarmerMarketParticipation>();
    }
}
