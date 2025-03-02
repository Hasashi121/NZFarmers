using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public class FarmersLocation
    {
        [Key]
        public int FarmerLocationID { get; set; }  // Unique identifier

        [Required(ErrorMessage = "Farmer association is required.")]
        public int FarmerID { get; set; } // Correct foreign key property

        [ForeignKey("FarmersID")] // Correctly reference the foreign key property name here
        public virtual Farmers Farmer { get; set; } // Navigation property

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State or region is required.")]
        [StringLength(100, ErrorMessage = "State or region name cannot exceed 100 characters.")]
        public string Region { get; set; }

        [StringLength(20, ErrorMessage = "Zip code must not exceed 20 characters.")]
        public string? ZipCode { get; set; }
    }
}
