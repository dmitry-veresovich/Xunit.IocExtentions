using System;

namespace Xunit.IocExtentions.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DependencyAttribute : Attribute
    {
        private readonly Type _baseType;
        private readonly Type _implementedByType;

        public DependencyAttribute(Type baseType, Type implementedByType)
        {
            _baseType = baseType;
            _implementedByType = implementedByType;
        }

        public Type BaseType { get { return _baseType; } }
        public Type ImplementedByType { get { return _implementedByType; } }

    }
}