using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class FarmerMarkets
    {
        [Key]
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event title is required.")]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required.")]
        [MaxLength(255)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime Date { get; set; }

        [MaxLength(2000)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for event participation
        public virtual ICollection<FarmerMarketParticipation> FarmerMarketParticipations { get; set; } = new List<FarmerMarketParticipation>();
    }
}
