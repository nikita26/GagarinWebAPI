using DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using UseCases;

namespace GagarinWebAPI.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly UseCasesAuthentication _useCasesAuthentication;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,UseCasesAuthentication useCasesAuthentication)
            : base(options, logger, encoder, clock)
        {
            _useCasesAuthentication = useCasesAuthentication;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"];
            if(!authHeader.Any())
                return AuthenticateResult.Fail("UnAuthorized");

            var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
            var userAuthValue = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue.Parameter)).Split(":");
            
            var authResult = await _useCasesAuthentication.AuthenticateUserAsync(userAuthValue[0], userAuthValue[1]);
            
            if (authResult)
            {
                var claim = new[] { new Claim(ClaimTypes.Name, userAuthValue[0]) };
                var identity = new ClaimsIdentity(claim,Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal,Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            return AuthenticateResult.Fail("UnAuthorized");
        }
    }
}
