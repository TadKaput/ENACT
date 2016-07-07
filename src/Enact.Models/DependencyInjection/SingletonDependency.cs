using Microsoft.Extensions.DependencyInjection;

namespace Enact.Models.DependencyInjection
{
    /// <summary>
    /// Specifies that a single instance of the service will be created.
    /// </summary>
    public class SingletonDependency : DependencyAttribute
    {
        public SingletonDependency() : base(ServiceLifetime.Singleton)
        {
        }
    }
}
