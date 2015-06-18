using System;
using System.Collections.Generic;
using Autofac;
using Xunit.IocExtentions.Attributes;

namespace Xunit.IocExtentions.Resolvers
{
    class AutofacTypeResolver : ITypeResolver
    {
        private readonly IContainer _container;

        public AutofacTypeResolver(IEnumerable<DependencyAttribute> dependencies, Type typeToResolve)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType(typeToResolve);
            foreach (var dependency in dependencies)
                containerBuilder.RegisterType(dependency.ImplementedByType).As(dependency.BaseType);

            _container = containerBuilder.Build();
        }

        public object Resolve(Type typeToResolve)
        {
            return _container.Resolve(typeToResolve);
        }
    }
}