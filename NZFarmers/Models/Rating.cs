using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class Rating
    {
        [Key]
        public int RatingID { get; set; }  // Unique identifier

        [Required(ErrorMessage = "User is required.")]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; } = default!;

        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }
        [ForeignKey("FarmerID")]
        public virtual Farmers Farmer { get; set; } = default!;

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int RatingValue { get; set; }

        [StringLength(2000, ErrorMessage = "Comment is too long.")]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
