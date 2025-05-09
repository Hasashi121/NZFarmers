// Required namespaces for validation and database mapping
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    // Represents a community or local farmer market event
    public class FarmerMarketEvent
    {
        // Primary key for identifying the event
        [Key]
        public int EventID { get; set; }

        // Title of the event — required and limited to 255 characters
        [Required(ErrorMessage = "Event title is required.")]
        [StringLength(255, ErrorMessage = "Event title cannot exceed 255 characters.")]
        public string Title { get; set; } = string.Empty;

        // Physical or virtual location of the event — required and limited to 255 characters
        [Required(ErrorMessage = "Event location is required.")]
        [StringLength(255, ErrorMessage = "Event location cannot exceed 255 characters.")]
        public string Location { get; set; } = string.Empty;

        // The scheduled date of the event — required and validated as a proper date format
        [Required(ErrorMessage = "Event date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime Date { get; set; }

        // Optional description providing more context or details about the event
        [StringLength(2000, ErrorMessage = "Event description is too long.")]
        public string? Description { get; set; }

        // Timestamp for when the event record was created — defaults to current UTC time
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property to link farmers participating in this event
        public virtual ICollection<FarmerMarketParticipation> FarmerMarketParticipations { get; set; } = new List<FarmerMarketParticipation>();
    }
}
