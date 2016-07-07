using Microsoft.Extensions.DependencyInjection;

namespace Enact.Models.DependencyInjection
{
    /// <summary>
    /// Specifies that a new instance of the service will be created every time it is requested.
    /// </summary>
    public class TransientDependency : DependencyAttribute
    {
        public TransientDependency() : base(ServiceLifetime.Transient)
        {
        }
    }
}
