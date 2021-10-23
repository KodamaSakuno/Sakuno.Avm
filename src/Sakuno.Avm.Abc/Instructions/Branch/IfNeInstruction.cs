namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfNe)]
    public sealed partial class IfNeInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfNeInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfNe)
        {
            JumpOffset = jumpOffset;
        }
    }
}
