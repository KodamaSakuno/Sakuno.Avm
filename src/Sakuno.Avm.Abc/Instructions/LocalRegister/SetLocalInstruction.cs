namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SetLocal)]
    public sealed partial class SetLocalInstruction : AbcInstruction
    {
        public int RegisterIndex { get; }

        internal SetLocalInstruction([Argument(ArgumentKind.U30)] int registerIndex) : base(InstructionKind.SetLocal)
        {
            RegisterIndex = registerIndex;
        }
    }
}
