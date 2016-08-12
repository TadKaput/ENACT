using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Enact.Models.DependencyInjection;
using Enact.Models.RepositoryInjection;
using Enact.Repository.Sql.Test;
using Enact.Repository.Es.Test;
using Enact.Repository.Es;
using Microsoft.Extensions.Configuration;

namespace Enact.Api.Config
{
    //http://dotnetliberty.com/index.php/2016/01/11/dependency-scanning-in-asp-net-5/
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDependencyScanning().ScanAllAssemblies();

            //manual DI configuration goes here       
            if (config["Db"] == "ES")
            {
                services.AddSingleton<ITestRepository, ElasticSearchTestRepository>(_ => new ElasticSearchTestRepository(new RepositoryClient(config["Es:Uri"], config["Es:Indices:Test"])));
            }
            else if (config["Db"] == "EF")
            {
                services.AddSingleton<ITestRepository, SqlTestRepository>(_ => new SqlTestRepository(new object()));
            }
            return services;
        }
    }
}
