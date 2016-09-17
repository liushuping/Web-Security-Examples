using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BooksOnline.middleware;
using BooksOnline.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BooksOnline
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddMvc();
            services.AddAuthentication();
        }

        private void UseBasicAuthentication(IApplicationBuilder app)
        {
            app.UseBasicAuthentication(new BasicAuthenticationOptions
            {
                Realm = "Books online",
                ValidateCredentials = Validate,
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });
        }

        private void UseBearerAuthentication(IApplicationBuilder app)
        {
            // TODO: Add Key IDs and x5c strings.
            var keyIds = new[] { "<key_id1>", "<key_id2>", "<key_id3>" };
            var x5cArray = new[] { "<x5c_1>", "<x5c_2>", "<x5c_3>" };
            var x509Keys = new List<X509SecurityKey>();

            for (var i = 0; i < 3; ++i)
            {
                var id = keyIds[i];
                var x5c = x5cArray[i];
                var bytes = Convert.FromBase64String(x5c);
                var x509Certificate = new X509Certificate2(bytes);
                var x509Key = new X509SecurityKey(x509Certificate);
                x509Key.KeyId = id;
                x509Keys.Add(x509Key);
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKeys = x509Keys,

                ValidateIssuer = true,
                // TODO: enter STS issuer
                ValidIssuer = "<AAD STS issuer>",

                ValidateAudience = true,
                ValidAudience = "http://localhost:5000/",

                ValidateLifetime = true,
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // UseBasicAuthentication(app);
            // UseBearerAuthentication(app);

            app.UseMvc();
        }

        private bool Validate(string username, string password)
        {
            return username == "admin" && password == "admin";
        }
    }
}
