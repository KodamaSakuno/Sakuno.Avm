namespace Sakuno.Avm.Abc
{
    public sealed class AbcConstantDouble : AbcConstant
    {
        public double Value { get; }

        internal AbcConstantDouble(double value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}
