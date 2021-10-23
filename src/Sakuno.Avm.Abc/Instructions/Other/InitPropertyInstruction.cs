namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.InitProperty)]
    public sealed partial class InitPropertyInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal InitPropertyInstruction(AbcMultiname property) : base(InstructionKind.InitProperty)
        {
            Property = property;
        }
    }
}
