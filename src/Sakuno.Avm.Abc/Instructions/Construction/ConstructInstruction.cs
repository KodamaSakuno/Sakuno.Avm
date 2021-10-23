namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Construct)]
    public sealed partial class ConstructInstruction : AbcInstruction
    {
        public int ArgumentCount { get; }

        internal ConstructInstruction([Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.Construct)
        {
            ArgumentCount = argumentCount;
        }
    }
}
