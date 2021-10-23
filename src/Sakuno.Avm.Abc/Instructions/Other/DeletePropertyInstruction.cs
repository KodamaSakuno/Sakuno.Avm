namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.DeleteProperty)]
    public sealed partial class DeletePropertyInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal DeletePropertyInstruction(AbcMultiname property) : base(InstructionKind.DeleteProperty)
        {
            Property = property;
        }
    }
}
