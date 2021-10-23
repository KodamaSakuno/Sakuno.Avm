namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfNGe)]
    public sealed partial class IfNGeInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfNGeInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfNGe)
        {
            JumpOffset = jumpOffset;
        }
    }
}
