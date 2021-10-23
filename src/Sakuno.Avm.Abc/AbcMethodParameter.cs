using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMethodParameter
    {
        public string? Name { get; internal set; }
        public AbcMultiname Type { get; }

        public AbcConstant? DefaultValue { get; internal set; }

        public AbcMethodParameter(AbcMultiname type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
