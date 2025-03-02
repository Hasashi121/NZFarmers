using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class FarmerMarketParticipation
    {
        [Key]
        public int ParticipationID { get; set; }  // Unique identifier

        [Required(ErrorMessage = "Farmer is required.")]
        public int FarmerID { get; set; }
        [ForeignKey("FarmerID")]
        public virtual Farmers Farmer { get; set; } = default!;

        [Required(ErrorMessage = "Event is required.")]
        public int EventID { get; set; }
        [ForeignKey("EventID")]
        public virtual FarmerMarketEvent FarmerMarketEvent { get; set; } = default!;
    }
}
