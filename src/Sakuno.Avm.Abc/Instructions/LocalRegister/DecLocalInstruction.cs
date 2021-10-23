namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.DecLocal)]
    public sealed partial class DecLocalInstruction : AbcInstruction
    {
        public int RegisterIndex { get; }

        internal DecLocalInstruction([Argument(ArgumentKind.U30)] int registerIndex) : base(InstructionKind.DecLocal)
        {
            RegisterIndex = registerIndex;
        }
    }
}
