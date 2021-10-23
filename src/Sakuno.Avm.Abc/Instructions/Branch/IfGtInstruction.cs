namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfGt)]
    public sealed partial class IfGtInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfGtInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfGt)
        {
            JumpOffset = jumpOffset;
        }
    }
}
