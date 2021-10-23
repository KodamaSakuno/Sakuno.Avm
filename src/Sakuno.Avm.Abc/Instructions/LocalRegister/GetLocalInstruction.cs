namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetLocal)]
    public sealed partial class GetLocalInstruction : AbcInstruction
    {
        public int RegisterIndex { get; }

        internal GetLocalInstruction([Argument(ArgumentKind.U30)] int registerIndex) : base(InstructionKind.GetLocal)
        {
            RegisterIndex = registerIndex;
        }
    }
}
