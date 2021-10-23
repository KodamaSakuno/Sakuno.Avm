namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfStrictEq)]
    public sealed partial class IfStrictEqInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfStrictEqInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfStrictEq)
        {
            JumpOffset = jumpOffset;
        }
    }
}
