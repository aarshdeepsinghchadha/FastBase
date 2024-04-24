using AutoMapper;
using FastBase.Domain.Admin;
using FastBase.Email.Interface;
using FastBase.SchemaBuilder;
using FastBase.Shared.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using FastBase.Core.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastBase.Authentication.Service
{
    public class AuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IResponseGeneratorService _responseGeneratorService;
        private readonly ITokenService _tokenService;
        private readonly IEmailSenderService _emailSender;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
    }
}
