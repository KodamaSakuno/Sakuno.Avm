namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfEq)]
    public sealed partial class IfEqInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfEqInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfEq)
        {
            JumpOffset = jumpOffset;
        }
    }
}
