namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Jump)]
    public sealed partial class JumpInstruction : AbcInstruction
    {
        public int JumpOffset { get; }

        internal JumpInstruction([Argument(ArgumentKind.S24)] int jumpOffset) : base(InstructionKind.Jump)
        {
            JumpOffset = jumpOffset;
        }
    }
}
