using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMultinameTypeName : AbcMultiname
    {
        public AbcMultiname Name { get; }

        public IReadOnlyList<AbcMultiname> Parameters { get; }

        internal AbcMultinameTypeName(AbcMultiname name, IReadOnlyList<AbcMultiname> parameters) : base(MultinameKind.TypeName)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }
    }
}
