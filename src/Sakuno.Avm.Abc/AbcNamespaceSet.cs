using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcNamespaceSet
    {
        public IReadOnlyList<AbcNamespace> Namespaces { get; }

        internal AbcNamespaceSet(IReadOnlyList<AbcNamespace> namespaces)
        {
            Namespaces = namespaces ?? throw new ArgumentNullException(nameof(namespaces));
        }
    }
}
