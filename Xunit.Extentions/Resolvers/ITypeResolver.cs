using System;

namespace Xunit.Extentions.Resolvers
{
    internal interface ITypeResolver
    {
        object Resolve(Type typeToResolve);
    }
}