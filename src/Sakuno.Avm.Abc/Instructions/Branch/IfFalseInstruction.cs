namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IfFalse)]
    public sealed partial class IfFalseInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal IfFalseInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.IfFalse)
        {
            JumpOffset = jumpOffset;
        }
    }
}
