using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

//http://dotnetliberty.com/index.php/2016/01/11/dependency-scanning-in-asp-net-5/
//https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/DependencyInjection/ServiceLifetime/
namespace Enact.Models.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class DependencyAttribute : Attribute
    {
        public ServiceLifetime DependencyType { get; set; }

        public Type ServiceType { get; set; }

        protected DependencyAttribute(ServiceLifetime dependencyType)
        {
            DependencyType = dependencyType;
        }

        public ServiceDescriptor BuildServiceDescriptor(TypeInfo type)
        {
            var serviceType = ServiceType ?? type.AsType();
            return new ServiceDescriptor(serviceType, type.AsType(), DependencyType);
        }
    }
}
