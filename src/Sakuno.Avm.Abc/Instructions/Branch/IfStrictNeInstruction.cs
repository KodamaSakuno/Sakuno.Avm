namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfStrictNe)]
    public sealed partial class IfStrictNeInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfStrictNeInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfStrictNe)
        {
            JumpOffset = jumpOffset;
        }
    }
}
