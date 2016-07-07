using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.Linq;
using System.Collections.Generic;

namespace Enact.Api.Config
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyScanning(this IServiceCollection services)
        {
            services.AddSingleton<DependencyInjectionScanner>();
            return services;
        }
        
        public static IServiceCollection ScanAllAssemblies(this IServiceCollection services)
        {
            var allCustomAssemblies = GetAssemblies().Where(a => a.FullName.StartsWith("Enact."));  //"Where" clause is not necessary, just used for clarity.

            foreach (var assembly in allCustomAssemblies)
            {
                var scanner = services.GetScanner();
                scanner.RegisterAssembly(services, assembly);
            }
            return services;
        }
        
        private static DependencyInjectionScanner GetScanner(this IServiceCollection services)
        {
            var scanner = services.BuildServiceProvider().GetService<DependencyInjectionScanner>();
            if (null == scanner)
            {
                throw new InvalidOperationException(
                    "Unable to resolve scanner. Did you forget to call services.AddDependencyScanning?");
            }
            return scanner;
        }

        #region Helper GetAssemblies()

        //http://stackoverflow.com/questions/851248/c-sharp-reflection-get-all-active-assemblies-in-a-solution
        public static IEnumerable<Assembly> GetAssemblies()
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();

            stack.Push(Assembly.GetEntryAssembly());

            do
            {
                var asm = stack.Pop();

                yield return asm;

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName) && reference.FullName.StartsWith("Enact"))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }

            }
            while (stack.Count > 0);

        }

        #endregion
    }
}
