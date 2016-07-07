using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Api.Config
{
    public static class Swashbuckle
    {
        public static IServiceCollection AddSwashbuckle(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "ENACT",
                    Description = "Enterprise N-Tier Api CORE Template",
                    TermsOfService = "created by Tad Kaput",
                });
                //options.IncludeXmlComments(pathToDoc);  //TODO:  Include this with a relative path
                options.DescribeAllEnumsAsStrings();
            });
            return services;
        }

        public static IApplicationBuilder UseSwashbuckle(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUi("swashbuckle");
            return app;
        }
    }
}
