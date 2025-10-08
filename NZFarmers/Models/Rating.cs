using System.ComponentModel.DataAnnotations;           // Provides data annotation attributes like [Required], [Key], [Range]
using System.ComponentModel.DataAnnotations.Schema;    // Enables schema-related attributes like [ForeignKey]
using NZFarmers.Areas.Identity.Data;                  // Import custom Identity user model (NZFarmersUser)

namespace NZFarmers.Models
{
    // This class represents a review or rating left by a user for a farmer.
    public class Rating
    {
        // Primary key for the Rating entity
        [Key]
        public int RatingID { get; set; }

        // ID of the user who gave the rating (foreign key to AspNetUsers table)
        [Required(ErrorMessage = "User is required.")]
        public string UserId { get; set; } = string.Empty;

        // Navigation property to the user who submitted the rating
        [ForeignKey("UserId")]
        public virtual NZFarmersUser User { get; set; } = default!;

        // ID of the farmer being rated
        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }

        // Navigation property to the Farmer who was rated
        [ForeignKey("FarmerID")]
        public virtual Farmers Farmer { get; set; } = default!;

        // The numeric rating value, constrained between 1 and 10
        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int RatingValue { get; set; }

        // Optional comment provided by the user
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string? Comment { get; set; }

        // Timestamp of when the rating was submitted
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}