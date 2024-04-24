using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Models
{
    public class ResetPasswordDto : IValidatableObject
    {
        public string Email { get; set; } = null!;
        public string OTP { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string NewConfirmPassword { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult("Email is Required.", new[] { nameof(Email) });
            }

            if (string.IsNullOrWhiteSpace(OTP))
            {
                yield return new ValidationResult("OTP is Required.", new[] { nameof(OTP) });
            }

            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                yield return new ValidationResult("New Password is Required.", new[] { nameof(NewPassword) });
            }

            if (string.IsNullOrWhiteSpace(NewConfirmPassword))
            {
                yield return new ValidationResult("New Confirm Password is Required.", new[] { nameof(NewConfirmPassword) });
            }

            if (NewPassword != NewConfirmPassword)
            {
                yield return new ValidationResult("New Password and New Confirm Password do not match.", new[] { nameof(NewPassword), nameof(NewConfirmPassword) });
            }
        }
    }
}
