using FastBase.Domain.Admin;

namespace FastBase.Authentication.Models
{
    public class DecodeTokenDto
    {
        public bool Status { get; set; }
        public AppUser UserDetails { get; set; } = null!;
    }
}
