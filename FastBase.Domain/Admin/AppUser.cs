using Microsoft.AspNetCore.Identity;

namespace FastBase.Domain.Admin
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
