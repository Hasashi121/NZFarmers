using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class EducationalContent
    {
        [Key]
        public int ContentID { get; set; }

        [Required(ErrorMessage = "Content title is required.")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Content URL is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        public string ContentURL { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
