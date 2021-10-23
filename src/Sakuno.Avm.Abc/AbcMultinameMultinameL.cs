using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMultinameMultinameL : AbcMultiname
    {
        public bool IsAttribute { get; }

        public AbcNamespaceSet NamespaceSet { get; }

        internal AbcMultinameMultinameL(MultinameKind kind, AbcNamespaceSet namespaceSet) : base(kind)
        {
            IsAttribute = kind == MultinameKind.MultinameLA;

            NamespaceSet = namespaceSet ?? throw new ArgumentNullException(nameof(namespaceSet));
        }
    }
}
