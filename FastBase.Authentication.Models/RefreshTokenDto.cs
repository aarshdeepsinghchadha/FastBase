using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Models
{
    public class RefreshTokenDto
    {
        public string OldToken { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
