namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.FindPropertyStrict)]
    public sealed partial class FindPropertyStrictInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal FindPropertyStrictInstruction(AbcMultiname property) : base(InstructionKind.FindPropertyStrict)
        {
            Property = property;
        }
    }
}
