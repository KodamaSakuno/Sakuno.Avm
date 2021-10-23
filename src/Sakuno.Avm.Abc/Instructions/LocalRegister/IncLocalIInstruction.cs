namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IncLocalI)]
    public sealed partial class IncLocalIInstruction : AbcInstruction
    {
        public int RegisterIndex { get; }

        internal IncLocalIInstruction([Argument(ArgumentKind.U30)] int registerIndex) : base(InstructionKind.IncLocalI)
        {
            RegisterIndex = registerIndex;
        }
    }
}
