namespace Sakuno.Avm.Abc
{
    public sealed class AbcConstantInteger : AbcConstant
    {
        public int Value { get; }

        internal AbcConstantInteger(int value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}
