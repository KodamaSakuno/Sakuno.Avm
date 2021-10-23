namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.FindProperty)]
    public sealed partial class FindPropertyInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal FindPropertyInstruction(AbcMultiname property) : base(InstructionKind.FindProperty)
        {
            Property = property;
        }
    }
}
