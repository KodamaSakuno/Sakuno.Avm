namespace Sakuno.Avm.Abc
{
    public sealed class AbcMultinameRTQNameL : AbcMultiname
    {
        internal static readonly AbcMultinameRTQNameL Instance = new(MultinameKind.RTQNameL);
        internal static readonly AbcMultinameRTQNameL AttributeInstance = new(MultinameKind.RTQNameLA);

        public bool IsAttribute { get; }

        internal AbcMultinameRTQNameL(MultinameKind kind) : base(kind)
        {
            IsAttribute = kind == MultinameKind.RTQNameLA;
        }
    }
}
