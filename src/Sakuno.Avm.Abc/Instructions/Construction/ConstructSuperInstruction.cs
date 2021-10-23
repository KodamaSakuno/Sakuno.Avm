namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ConstructSuper)]
    public sealed partial class ConstructSuperInstruction : AbcInstruction
    {
        public int ArgumentCount { get; }

        internal ConstructSuperInstruction([Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.ConstructSuper)
        {
            ArgumentCount = argumentCount;
        }
    }
}
