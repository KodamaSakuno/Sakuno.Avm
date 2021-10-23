namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetProperty)]
    public sealed partial class GetPropertyInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal GetPropertyInstruction(AbcMultiname property) : base(InstructionKind.GetProperty)
        {
            Property = property;
        }
    }
}
