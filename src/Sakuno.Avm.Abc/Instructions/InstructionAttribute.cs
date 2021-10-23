using System;

namespace Sakuno.Avm.Abc.Instructions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class InstructionAttribute : Attribute
    {
        public InstructionKind Kind { get; }

        public InstructionAttribute(InstructionKind code)
        {
            Kind = code;
        }
    }
}
