using System;

namespace Sakuno.Avm.Abc.Instructions
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
    internal sealed class ArgumentAttribute : Attribute
    {
        public ArgumentKind Kind { get; }

        public ArgumentAttribute(ArgumentKind kind)
        {
            Kind = kind;
        }
    }
}
