namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushNamespace)]
    public sealed partial class PushNamespaceInstruction : AbcInstruction
    {
        public AbcNamespace Value { get; }

        internal PushNamespaceInstruction(AbcNamespace value) : base(InstructionKind.PushNamespace)
        {
            Value = value;
        }
    }
}
