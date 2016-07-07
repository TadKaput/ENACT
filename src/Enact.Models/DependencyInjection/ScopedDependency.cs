using Microsoft.Extensions.DependencyInjection;

namespace Enact.Models.DependencyInjection
{
    /// <summary>
    /// Specifies that a new instance of the service will be created for each scope.
    /// </summary>
    public class ScopedDependency : DependencyAttribute
    {
        public ScopedDependency() : base(ServiceLifetime.Scoped)
        {
        }
    }
}
