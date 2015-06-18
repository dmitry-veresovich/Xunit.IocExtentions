using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.IocExtentions.Resolvers;
using Xunit.Sdk;

namespace Xunit.IocExtentions.Attributes
{
    public class AutofacDataAttribute : DataAttribute
    {
        private readonly Type _typeToResolve;
        private readonly object[] _data;

        public AutofacDataAttribute(Type typeToResolve, params object[] data)
        {
            _typeToResolve = typeToResolve;
            _data = data;
        }


        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var resultList = new List<object>();
            var typeResolver = new AutofacTypeResolver(testMethod.GetCustomAttributes<DependencyAttribute>(), _typeToResolve);
            var resolved = typeResolver.Resolve(_typeToResolve);
            resultList.Add(resolved);
            resultList.AddRange(_data);
            return new object[1][] { resultList.ToArray() };
        }
    }
}