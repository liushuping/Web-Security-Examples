using System;
using Microsoft.AspNetCore.Builder;

public static class BasicAppBuilderExtensions
{
    /// <summary>
    /// Adds a basic authentication middleware to your web application pipeline. This method does not attempt to obtain options though `IOptions`.
    /// </summary>
    /// <param name="app">The IApplicationBuilder passed to your configuration method</param>
    /// <param name="configureOptions">Used to configure the options for the middleware</param>
    /// <returns>The original app parameter</returns>
    public static IApplicationBuilder UseBasicAuthentication(this IApplicationBuilder app, Action<BasicAuthenticationOptions> configureOptions)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        var options = new BasicAuthenticationOptions();
        if (configureOptions != null)
            configureOptions(options);

        return app.UseBasicAuthentication(options);
    }

    /// <summary>
    /// Adds a basic authentication middleware to your web application pipeline.  This method does not attempt to obtain options though `IOptions`.
    /// </summary>
    /// <param name="app">The IApplicationBuilder passed to your configuration method</param>
    /// <param name="options">Used to configure the middleware</param>
    /// <returns>The original app parameter</returns>
    public static IApplicationBuilder UseBasicAuthentication(this IApplicationBuilder app, BasicAuthenticationOptions options)
    {
        if (app == null)
            throw new ArgumentNullException(nameof(app));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        return app.UseMiddleware<BasicAuthenticationMiddleware>(options);
    }
}