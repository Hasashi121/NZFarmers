using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class EducationalContent
    {
        [Key]
        public int ContentID { get; set; }  // Unique identifier

        [Required(ErrorMessage = "Content title is required.")]
        [StringLength(255, ErrorMessage = "Content title cannot exceed 255 characters.")]
        public string Title { get; set; }

        [StringLength(2000, ErrorMessage = "Content description is too long.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Content URL is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        public string ContentURL { get; set; }  // Link to the educational material

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
