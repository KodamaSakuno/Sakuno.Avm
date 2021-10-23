using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMultinameQName : AbcMultiname
    {
        public bool IsAttribute { get; }

        public AbcNamespace Namespace { get; }
        public string Name { get; }

        internal AbcMultinameQName(MultinameKind kind, AbcNamespace @namespace, string? name) : base(kind)
        {
            IsAttribute = kind == MultinameKind.QNameA;

            Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
            Name = name ?? "*";
        }

        public override string ToString() => "[QName] " + Name;
    }
}
