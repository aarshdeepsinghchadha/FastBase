using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Models
{
    public class GetAllUserDto
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;   
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public bool EmailConfirmed { get; set; } = false;
    }
}
