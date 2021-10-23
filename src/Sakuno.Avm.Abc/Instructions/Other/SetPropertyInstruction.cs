namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SetProperty)]
    public sealed partial class SetPropertyInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal SetPropertyInstruction(AbcMultiname property) : base(InstructionKind.SetProperty)
        {
            Property = property;
        }
    }
}
