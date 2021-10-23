namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetSuper)]
    public sealed partial class GetSuperInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal GetSuperInstruction(AbcMultiname property) : base(InstructionKind.GetSuper)
        {
            Property = property;
        }
    }
}
