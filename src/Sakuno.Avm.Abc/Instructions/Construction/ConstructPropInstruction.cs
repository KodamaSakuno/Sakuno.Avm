namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ConstructProp)]
    public sealed partial class ConstructPropInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }
        public int ArgumentCount { get; }

        internal ConstructPropInstruction(AbcMultiname property, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.ConstructProp)
        {
            Property = property;
            ArgumentCount = argumentCount;
        }
    }
}
