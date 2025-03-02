using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class FarmerMarketEvent
    {
        [Key]
        public int EventID { get; set; }  // Unique identifier

        [Required(ErrorMessage = "Event title is required.")]
        [StringLength(255, ErrorMessage = "Event title cannot exceed 255 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Event location is required.")]
        [StringLength(255, ErrorMessage = "Event location description cannot exceed 255 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime Date { get; set; }

        [StringLength(2000, ErrorMessage = "Event description is too long.")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for linking with farmer participation
        public virtual ICollection<FarmerMarketParticipation> FarmerMarketParticipations { get; set; } = new List<FarmerMarketParticipation>();
    }
}
