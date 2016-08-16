using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Enact.Models.DependencyInjection;
using Enact.Models.RepositoryInjection;
using Enact.Repository.Sql.Test;
using Enact.Repository.Es.Test;
using Enact.Repository.Es;
using Enact.Repository.Sql;
using Microsoft.Extensions.Configuration;
using Enact.Models.TestModel;

namespace Enact.Api.Config
{
    //http://dotnetliberty.com/index.php/2016/01/11/dependency-scanning-in-asp-net-5/
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDependencyScanning().ScanAllAssemblies();

            //manual DI configuration goes here

            services.AddSingleton(_ => new ElasticSearchTestRepository(new RepositoryClient(config["Es:Uri"], config["Es:Indices:Test"])));
            //services.AddSingleton<SqlCrudRepository<TestModel>, SqlTestRepository>(_ => new SqlTestRepository(new object()));
            
            return services;
        }
    }
}
