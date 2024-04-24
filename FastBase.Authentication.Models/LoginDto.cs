using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Models
{
    public class LoginDto : IValidatableObject
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrWhiteSpace(Username))
            {
                yield return new ValidationResult("Username is Required.", new[] {nameof(Username)});
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("Password is Required.", new[] { nameof(Password) });
            }
        }
    }
}
