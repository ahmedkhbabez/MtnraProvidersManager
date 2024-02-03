using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MtnraProvidersManager_PAL.Extensions
{
    public static class SecurityExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, ConfigurationManager configuraion) =>
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder =>
                builder.WithOrigins(configuraion.GetSection("ClientUrls").Get<string[]>())
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureAuthentication(this IServiceCollection services,
            ConfigurationManager configuration)
            => services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration.GetSection("TokenSecurityKey").Value)
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
    }
}
