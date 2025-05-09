// Import validation attributes from the data annotations namespace
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    // This class defines a farmer market event entity
    public class FarmerMarkets
    {
        // Primary key for the event
        [Key]
        public int EventID { get; set; }

        // The title of the event, required and limited to 255 characters
        [Required(ErrorMessage = "Event title is required.")]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        // The location where the event is being held, required and limited to 255 characters
        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(255)]
        public string Location { get; set; } = string.Empty;

        // The date the event will take place
        [Required(ErrorMessage = "Event date is required.")]
        public DateTime Date { get; set; }

        // An optional description of the event, up to 2000 characters
        [MaxLength(2000)]
        public string? Description { get; set; }

        // Timestamp when the event was created, defaults to the current UTC date/time
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property: connects this event to a list of participating farmers
        public virtual ICollection<FarmerMarketParticipation> FarmerMarketParticipations { get; set; } = new List<FarmerMarketParticipation>();
    }
}
