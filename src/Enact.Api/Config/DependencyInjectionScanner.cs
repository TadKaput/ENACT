using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Enact.Models.DependencyInjection;


namespace Enact.Api.Config
{
    public class DependencyInjectionScanner
    {
        public void RegisterAssembly(IServiceCollection services, Assembly assembly)
        {
            foreach (var type in assembly.DefinedTypes)
            {
                var dependencyAttributes = type.GetCustomAttributes<DependencyAttribute>();
                // Each dependency can be registered as various types
                foreach (var dependencyAttribute in dependencyAttributes)
                {
                    var serviceDescriptor = dependencyAttribute.BuildServiceDescriptor(type);
                    services.Add(serviceDescriptor);
                }
            }
        }
    }
}
