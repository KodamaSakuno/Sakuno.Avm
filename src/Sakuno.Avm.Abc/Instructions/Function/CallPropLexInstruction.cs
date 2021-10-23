namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CallPropLex)]
    public sealed partial class CallPropLexInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }
        public int ArgumentCount { get; }

        internal CallPropLexInstruction(AbcMultiname property, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.CallPropLex)
        {
            Property = property;
            ArgumentCount = argumentCount;
        }
    }
}
