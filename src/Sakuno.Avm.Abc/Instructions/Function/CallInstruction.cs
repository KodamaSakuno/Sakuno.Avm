namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Call)]
    public sealed partial class CallInstruction : AbcInstruction
    {
        public int ArgumentCount { get; }

        internal CallInstruction([Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.Call)
        {
            ArgumentCount = argumentCount;
        }
    }
}
