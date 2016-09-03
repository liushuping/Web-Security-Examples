using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;

namespace BooksOnline.middleware
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                var authHeader = Context.Request.Headers["Authorization"][0];
                var token = authHeader.Substring("Basic ".Length).Trim();
                var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialstring.Split(':');
                var validate = Options.ValidateCredentials;
                if (validate != null && validate(credentials[0], credentials[1]))
                {
                    var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    Context.User = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties();
                    var ticket = new AuthenticationTicket(Context.User, properties, "Basic");
                    return await Task.FromResult(AuthenticateResult.Success(ticket));
                }

                return await Fail();
            }
            catch
            {
                return await Fail();
            }
        }

        private async Task<AuthenticateResult> Fail()
        {
            var realm = Options.Realm;
            Context.Response.StatusCode = 401;
            if (string.IsNullOrWhiteSpace(realm))
            {
                realm = "My Realm";
            }

            Context.Response.Headers.Add("WWW-Authenticate", $"Basic realm=\"{realm}\"");
            return await Task.FromResult(AuthenticateResult.Fail("Authentication credentials are missing or invalid."));
        }
    }
}