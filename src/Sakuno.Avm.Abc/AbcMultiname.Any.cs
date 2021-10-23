namespace Sakuno.Avm.Abc
{
    public sealed class AbcMultinameAny : AbcMultiname
    {
        internal AbcMultinameAny() : base(MultinameKind.Any) { }

        public override string ToString() => "*";
    }
}
