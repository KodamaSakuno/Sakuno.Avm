namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IncLocal)]
    public sealed partial class IncLocalInstruction : AbcInstruction
    {
        public int RegisterIndex { get; }

        internal IncLocalInstruction([Argument(ArgumentKind.U30)] int registerIndex) : base(InstructionKind.IncLocal)
        {
            RegisterIndex = registerIndex;
        }
    }
}
