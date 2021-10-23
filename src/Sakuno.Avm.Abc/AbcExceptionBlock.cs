using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcExceptionBlock
    {
        public int From { get; }
        public int To { get; }
        public int Target { get; }
        public AbcMultiname ExceptionType { get; }
        public AbcMultiname? VariableName { get; }

        internal AbcExceptionBlock(int from, int to, int target, AbcMultiname exceptionType, AbcMultiname? variableName)
        {
            From = from;
            To = to;
            Target = target;
            ExceptionType = exceptionType ?? throw new ArgumentNullException(nameof(exceptionType));
            VariableName = variableName;
        }
    }
}
