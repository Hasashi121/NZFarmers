// Required namespaces for validation attributes and entity framework annotations
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    // This model connects a Farmer to a specific FarmerMarketEvent (many-to-many relationship)
    public class FarmerMarketParticipation
    {
        // Primary key for the participation record
        [Key]
        public int ParticipationID { get; set; }

        // Foreign key linking to the Farmer who is participating
        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }

        // Navigation property to access full Farmer details
        [ForeignKey(nameof(FarmerID))]
        public virtual Farmers Farmer { get; set; } = default!;

        // Foreign key linking to the Event in which the farmer is participating
        [Required(ErrorMessage = "Event is required.")]
        public int EventID { get; set; }

        // Navigation property to access full FarmerMarketEvent details
        [ForeignKey(nameof(EventID))]
        public virtual FarmerMarketEvent FarmerMarketEvent { get; set; } = default!;
    }
}
