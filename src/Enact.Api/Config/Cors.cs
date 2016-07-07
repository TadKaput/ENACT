using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enact.Api.Config
{
    public static class Cors
    {
        public const string ALLOW_SPECIFIC_ORIGIN = "AllowSpecificOrigin";

        public static IServiceCollection AddCors_OriginRestricted(this IServiceCollection services)
        {
            var restrictedBuilder = new CorsPolicyBuilder();
            restrictedBuilder.WithOrigins("http://localhost:4001");
            restrictedBuilder.AllowAnyHeader();
            restrictedBuilder.AllowAnyMethod();
            restrictedBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy(ALLOW_SPECIFIC_ORIGIN, restrictedBuilder.Build());
            });
            
            return services;
        }

        public static IApplicationBuilder UseCors_OriginRestricted(this IApplicationBuilder app)
        {
            app.UseCors(ALLOW_SPECIFIC_ORIGIN);
            return app;
        }
    }
}
