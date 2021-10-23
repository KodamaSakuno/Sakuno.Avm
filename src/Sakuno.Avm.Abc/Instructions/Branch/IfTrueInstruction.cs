namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfTrue)]
    public sealed partial class IfTrueInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfTrueInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfTrue)
        {
            JumpOffset = jumpOffset;
        }
    }
}
