using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcConstantNamespace : AbcConstant
    {
        public AbcNamespace Value { get; }

        internal AbcConstantNamespace(AbcNamespace value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString() => Value.ToString()!;
    }
}
