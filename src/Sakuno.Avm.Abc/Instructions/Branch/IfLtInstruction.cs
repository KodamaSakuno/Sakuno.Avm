namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfLt)]
    public sealed partial class IfLtInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfLtInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfLt)
        {
            JumpOffset = jumpOffset;
        }
    }
}
