using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZFarmers.Models
{
    public class FarmerMarketParticipation
    {
        [Key]
        public int ParticipationID { get; set; }

        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }
        [ForeignKey(nameof(FarmerID))]
        public virtual Farmers Farmer { get; set; } = default!;

        [Required(ErrorMessage = "Event is required.")]
        public int EventID { get; set; }
        [ForeignKey(nameof(EventID))]
        public virtual FarmerMarketEvent FarmerMarketEvent { get; set; } = default!;
    }
}
