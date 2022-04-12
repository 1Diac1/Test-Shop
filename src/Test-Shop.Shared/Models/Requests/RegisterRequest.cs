using System.ComponentModel.DataAnnotations;

namespace Test_Shop.Shared.Models.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email not specified")]
        [UIHint("Email"), EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [UIHint("Password")]
        public string Password { get; set; }

        [UIHint("Password")]
        [Compare("Password", ErrorMessage = "Password entered incorrectly")]
        public string ConfirmPassword { get; set; }

        public RegisterRequest(string firstName, string lastName, string email, string phoneNumber, string password, string confirmPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
