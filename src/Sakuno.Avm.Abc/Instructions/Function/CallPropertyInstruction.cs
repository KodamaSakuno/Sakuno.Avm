namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CallProperty)]
    public sealed partial class CallPropertyInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }
        public int ArgumentCount { get; }

        internal CallPropertyInstruction(AbcMultiname property, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.CallProperty)
        {
            Property = property;
            ArgumentCount = argumentCount;
        }
    }
}
