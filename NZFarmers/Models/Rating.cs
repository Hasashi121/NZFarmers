using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NZFarmers.Areas.Identity.Data; // Assuming this is your custom Identity user

namespace NZFarmers.Models
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }

        [Required(ErrorMessage = "User is required.")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public virtual NZFarmersUser User { get; set; } = default!;

        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }

        [ForeignKey("FarmerID")]
        public virtual Farmers Farmer { get; set; } = default!;

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int RatingValue { get; set; }

        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
