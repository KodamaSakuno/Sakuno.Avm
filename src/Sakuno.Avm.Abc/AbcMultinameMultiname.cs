using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMultinameMultiname : AbcMultiname
    {
        public bool IsAttribute { get; }

        public string Name { get; }
        public AbcNamespaceSet NamespaceSet { get; }

        internal AbcMultinameMultiname(MultinameKind kind, string? name, AbcNamespaceSet namespaceSet) : base(kind)
        {
            IsAttribute = kind == MultinameKind.MultinameA;

            Name = name ?? "*";
            NamespaceSet = namespaceSet ?? throw new ArgumentNullException(nameof(namespaceSet));
        }
    }
}
