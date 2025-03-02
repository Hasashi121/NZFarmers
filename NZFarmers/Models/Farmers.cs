using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class Farmers
    {
        [Key]
        public int FarmerID { get; set; }

        [Required(ErrorMessage = "User association is required.")]
        public int UserID { get; set; }

        // Use the foreign key attribute to reference the actual foreign key property, "UserID".
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Farm name is required.")]
        [StringLength(255, ErrorMessage = "Farm name cannot exceed 255 characters.")]
        public string FarmName { get; set; }

        [StringLength(2000, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Contact number must be between 10 and 15 digits and may include a leading '+'.")]
        public string ContactNumber { get; set; }

        [Url(ErrorMessage = "Invalid URL for profile image.")]
        public string? ProfileImage { get; set; }

        // Navigation properties
        public virtual ICollection<FarmersLocation> FarmerLocations { get; set; }
        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<FarmerMarketParticipation> FarmerMarketParticipations { get; set; }
    }

}

