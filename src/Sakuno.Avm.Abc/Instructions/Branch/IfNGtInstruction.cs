namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfNGt)]
    public sealed partial class IfNGtInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfNGtInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfNGt)
        {
            JumpOffset = jumpOffset;
        }
    }
}
