namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SetSuper)]
    public sealed partial class SetSuperInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal SetSuperInstruction(AbcMultiname property) : base(InstructionKind.SetSuper)
        {
            Property = property;
        }
    }
}
