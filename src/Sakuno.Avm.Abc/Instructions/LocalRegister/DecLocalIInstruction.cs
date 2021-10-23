namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.DecLocalI)]
    public sealed partial class DecLocalIInstruction : AbcInstruction
    {
        public int RegisterIndex { get; }

        internal DecLocalIInstruction([Argument(ArgumentKind.U30)] int registerIndex) : base(InstructionKind.DecLocalI)
        {
            RegisterIndex = registerIndex;
        }
    }
}
