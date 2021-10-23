namespace Sakuno.Avm.Abc
{
    public abstract class AbcMultiname
    {
        public static AbcMultinameAny Any { get; } = new();

        public MultinameKind Kind { get; }

        private protected AbcMultiname(MultinameKind kind)
        {
            Kind = kind;
        }
    }
}
