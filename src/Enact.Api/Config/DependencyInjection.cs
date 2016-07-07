using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Enact.Models.DependencyInjection;

namespace Enact.Api.Config
{
    //http://dotnetliberty.com/index.php/2016/01/11/dependency-scanning-in-asp-net-5/
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDependencyScanning().ScanAllAssemblies();
            
            //manual DI configuration goes here

            return services;
        }
    }
}
