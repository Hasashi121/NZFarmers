// Required namespace for validation and data annotations
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    // Represents an educational resource or article in the system
    public class EducationalContent
    {
        // Primary key for identifying the content
        [Key]
        public int ContentID { get; set; }

        // Title of the content — required and cannot exceed 255 characters
        [Required(ErrorMessage = "Content title is required.")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; } = string.Empty;

        // Optional description field with a maximum length of 2000 characters
        [StringLength(2000, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        // URL linking to the actual content — required and must be a valid URL
        [Required(ErrorMessage = "Content URL is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        public string ContentURL { get; set; } = string.Empty;

        // Automatically sets the time the content was created using UTC time
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
