using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class RegisterVM
    {
        // NIK
        [Key]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "NIK only accept number")]
        public string NIK { get; set; }

        // First Name
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Last Name
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        // Birth Date
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        // Gender
        public GenderEnum Gender { get; set; }

        // Email
        [EmailAddress]
        public string Email { get; set; }

        // Phone
        [Display(Name = "Phone Number"), Phone]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Wrong phone number format")]
        public string PhoneNumber { get; set; }

        // Major
        public string Major { get; set; }

        // Degree
        public string Degree { get; set; }

        // GPA
        [Range(0, 4, ErrorMessage = "The {0} Tidak boleh kurang {1} dan lebih dari {2}")]
        public double GPA { get; set; }

        // University Name
        [Display(Name = "University Name")]
        public string UniversityName { get; set; }

        // Password
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Password must have 8-15 characters, contain 1 uppercase, 1 lowercase, and 1 number")]
        public string Password { get; set; }

        // Confirm Password
        [DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
