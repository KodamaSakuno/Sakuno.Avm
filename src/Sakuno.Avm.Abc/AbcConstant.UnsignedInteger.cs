namespace Sakuno.Avm.Abc
{
    public sealed class AbcConstantUnsignedInteger : AbcConstant
    {
        public uint Value { get; }

        internal AbcConstantUnsignedInteger(uint value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString() + "u";
    }
}
