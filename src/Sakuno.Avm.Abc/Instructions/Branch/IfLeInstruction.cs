namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfLe)]
    public sealed partial class IfLeInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfLeInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfLe)
        {
            JumpOffset = jumpOffset;
        }
    }
}
