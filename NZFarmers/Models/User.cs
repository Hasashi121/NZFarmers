using System.ComponentModel.DataAnnotations;

namespace NZFarmers.Models
{
    public enum RoleType
    {
        Farmer,
        Consumer,
        Admin
    }
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Z][a-z]+\s?[A-Za-z]*$", ErrorMessage = "First name must begin with a capital letter and contain only letters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        [RegularExpression(@"^[A-Z][a-z]+\s?[A-Za-z]*$", ErrorMessage = "Last name must begin with a capital letter and contain only letters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(255, ErrorMessage = "Email address must not exceed 255 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "User role is required.")]
        [EnumDataType(typeof(RoleType), ErrorMessage = "Invalid role specified.")]
        public RoleType Role { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits and may include a leading '+'.")]
        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual Farmers?  Farmer { get; set; }


    }

    /// <summary>
    /// Represents the roles available within the application.
    /// </summary>
    

}
