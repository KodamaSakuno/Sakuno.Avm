namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfGe)]
    public sealed partial class IfGeInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfGeInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfGe)
        {
            JumpOffset = jumpOffset;
        }
    }
}
