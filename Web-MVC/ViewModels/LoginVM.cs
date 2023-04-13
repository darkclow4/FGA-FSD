using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class LoginVM
    {
        [Key]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
