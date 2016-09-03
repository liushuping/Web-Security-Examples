using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

public class BasicAuthenticationOptions : AuthenticationOptions, IOptions<BasicAuthenticationOptions>
{
    public BasicAuthenticationOptions()
    {
        AuthenticationScheme = "Basic";
        AutomaticAuthenticate = false;
    }

    public string Realm { get; set; }

    public BasicAuthenticationOptions Value
    {
        get
        {
            return this;
        }
    }
}