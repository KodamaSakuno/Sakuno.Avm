namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfNLe)]
    public sealed partial class IfNLeInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfNLeInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfNLe)
        {
            JumpOffset = jumpOffset;
        }
    }
}
