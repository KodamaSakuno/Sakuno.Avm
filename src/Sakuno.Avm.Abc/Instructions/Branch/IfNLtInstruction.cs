namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfNLt)]
    public sealed partial class IfNLtInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfNLtInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfNLt)
        {
            JumpOffset = jumpOffset;
        }
    }
}
