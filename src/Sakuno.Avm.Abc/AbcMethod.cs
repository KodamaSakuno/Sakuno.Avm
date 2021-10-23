using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMethod
    {
        public string Name { get; }
        public AbcMultiname ReturnType { get; }
        public IReadOnlyList<AbcMethodParameter> Parameters { get; }

        public AbcMethodBody Body { get; internal set; }

        internal AbcMethod(string name, AbcMultiname returnType, IReadOnlyList<AbcMethodParameter> parameters, MethodFlags flags)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ReturnType = returnType ?? throw new ArgumentNullException(nameof(returnType));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));

            Body = null!;
        }
    }
}
