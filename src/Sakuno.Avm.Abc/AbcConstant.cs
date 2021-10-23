namespace Sakuno.Avm.Abc
{
    public abstract class AbcConstant
    {
        public static AbcConstantUndefined Undefined { get; } = new();
        public static AbcConstantNull Null { get; } = new();

        public static AbcConstantTrue True { get; } = new();
        public static AbcConstantFalse False { get; } = new();

        private protected AbcConstant() { }

        public static implicit operator AbcConstant(int value) => new AbcConstantInteger(value);
        public static implicit operator AbcConstant(uint value) => new AbcConstantUnsignedInteger(value);
        public static implicit operator AbcConstant(double value) => new AbcConstantDouble(value);
        public static implicit operator AbcConstant(string value) => new AbcConstantString(value);
        public static implicit operator AbcConstant(bool value) => value ? True : False;
        public static implicit operator AbcConstant(AbcNamespace value) => new AbcConstantNamespace(value);
    }
}
