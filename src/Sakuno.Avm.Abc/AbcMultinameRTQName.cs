namespace Sakuno.Avm.Abc
{
    public sealed class AbcMultinameRTQName : AbcMultiname
    {
        public bool IsAttribute { get; }

        public string Name { get; }

        internal AbcMultinameRTQName(MultinameKind kind, string? name) : base(kind)
        {
            IsAttribute = kind == MultinameKind.RTQNameA;

            Name = name ?? "*";
        }
    }
}
