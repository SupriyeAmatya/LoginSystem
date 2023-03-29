using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace Login.Utils.Extensions
{
    public static class SwaggerExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services, string docPath)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(
                    "oauth2",
                    new OpenApiSecurityScheme
                    {
                        Description =
                            "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    }
                );
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                options.ExampleFilters();
                options.OperationFilter<AddResponseHeadersFilter>();

                try
                {
                    // TODO Add proper solution.
                    options.IncludeXmlComments(docPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
