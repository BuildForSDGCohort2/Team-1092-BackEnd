using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OlivetVehicleTracking.Entities;
using OlivetVehicleTracking.Models;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace OlivetVehicleTracking.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IdentityContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IdentityContext context,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager
            ) : base(options, logger, encoder, clock)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header was not found");
            }

            try
            {
                var AuthHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                var bytes = Convert.FromBase64String(AuthHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string Email = credentials[0];
                string Password = credentials[1];

                //var result = await _signInManager.PasswordSignInAsync(Email, Password, true, true);

                var user = await _userManager.FindByEmailAsync(Email);
                var password = await _userManager.CheckPasswordAsync(user, Password);               

                if (password) 
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, Email) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid username or password");
                }
                
            }
            catch(Exception e)
            {
                return AuthenticateResult.Fail("An error has occured");

            }         

            

        }
    }
}
