using System;
using System.Collections.Generic;
using Autofac;
using Xunit.IocExtentions.Attributes;

namespace Xunit.IocExtentions.Resolvers
{
    class AutofacTypeResolver : ITypeResolver
    {
        private readonly IContainer _container;
        private readonly Type _typeToResolve;

        public AutofacTypeResolver(IEnumerable<DependencyAttribute> dependencies, Type typeToResolve)
        {
            _typeToResolve = typeToResolve;
            _container = BuildContainer(dependencies);
        }


        public object Resolve()
        {
            return _container.Resolve(_typeToResolve);
        }


        private IContainer BuildContainer(IEnumerable<DependencyAttribute> dependencies)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType(_typeToResolve);
            foreach (var dependency in dependencies)
                containerBuilder.RegisterType(dependency.ImplementedByType).As(dependency.BaseType);

            return containerBuilder.Build();
        }
    }
}