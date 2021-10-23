namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CallPropVoid)]
    public sealed partial class CallPropVoidInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }
        public int ArgumentCount { get; }

        internal CallPropVoidInstruction(AbcMultiname property, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.CallPropVoid)
        {
            Property = property;
            ArgumentCount = argumentCount;
        }
    }
}
