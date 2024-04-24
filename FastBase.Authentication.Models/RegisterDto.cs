using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Models
{
    public class RegisterDto : IValidatableObject
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                yield return new ValidationResult("First Name is Required.", new[] { nameof(FirstName) });
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                yield return new ValidationResult("Last Name is Required.", new[] { nameof(LastName) });
            }

            if (string.IsNullOrWhiteSpace(Username))
            {
                yield return new ValidationResult("Username is Required.", new[] { nameof(Username) });
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("Password is Required.", new[] { nameof(Password) });
            }

            if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                yield return new ValidationResult("Confirm Password is Required.", new[] { nameof(ConfirmPassword) });
            }

            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("Password and Confirm Password do not match.", new[] { nameof(Password), nameof(ConfirmPassword) });
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult("Email is Required.", new[] { nameof(Email) });
            }

            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                yield return new ValidationResult("Phone Number is Required.", new[] { nameof(PhoneNumber) });
            }
        }
    }
}
