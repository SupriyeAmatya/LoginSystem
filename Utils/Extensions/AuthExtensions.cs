using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Login.Utils.Extensions
{
    public static class AuthExtension
    {
        public static void ConfigureAuth(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = configuration.GetSection("AppSettings:Token").Value;
            if (secretKey is null)
            {
                throw new KeyNotFoundException("Environment not set");
            }
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                        ValidAudience = jwtSettings.GetSection("validAudience").Value,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(secretKey)
                        )
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;

                            if (
                                !string.IsNullOrEmpty(accessToken)
                                && (
                                    path.StartsWithSegments("/notification")
                                    || path.StartsWithSegments("/chat")
                                )
                            )
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            if (
                                context.Exception.GetType() == typeof(SecurityTokenExpiredException)
                            )
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "StaffPolicy",
                    policy =>
                    {
                        policy.RequireClaim(ClaimTypes.UserData, "Staff"); // Require the "scope" claim with value "my_api"
                    }
                );
                options.AddPolicy(
                    "ClientPolicy",
                    policy =>
                    {
                        policy.RequireClaim(ClaimTypes.UserData, "Client"); // Require the "scope" claim with value "my_api"
                    }
                );
            });
        }
    }
}
