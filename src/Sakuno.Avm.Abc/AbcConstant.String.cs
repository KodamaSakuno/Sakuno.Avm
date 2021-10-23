using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcConstantString : AbcConstant
    {
        public string Value { get; }

        internal AbcConstantString(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString() => "\"" + Value + "\"";
    }
}
