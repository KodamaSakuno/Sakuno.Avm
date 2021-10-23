using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcNamespace
    {
        public NamespaceKind Kind { get; }
        public string Name { get; }

        internal AbcNamespace(NamespaceKind kind, string name)
        {
            Kind = kind;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
