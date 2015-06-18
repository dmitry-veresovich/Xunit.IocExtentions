using System;

namespace Xunit.IocExtentions.Resolvers
{
    internal interface ITypeResolver
    {
        object Resolve(Type typeToResolve);
    }
}