using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class BasicAuthenticationMiddleware : AuthenticationMiddleware<BasicAuthenticationOptions>
{
    protected RequestDelegate Next;

    public BasicAuthenticationMiddleware(RequestDelegate next,
                                         BasicAuthenticationOptions options,
                                         ILoggerFactory loggerFactory,
                                         UrlEncoder encoder) :
        base(next, options, loggerFactory, encoder)
    {
        Next = next;
    }

    protected override AuthenticationHandler<BasicAuthenticationOptions> CreateHandler()
    {
        return new BasicAuthenticationHandler();
    }
}