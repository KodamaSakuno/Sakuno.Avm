namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetLex)]
    public sealed partial class GetLexInstruction : AbcInstruction
    {
        public AbcMultiname Property { get; }

        internal GetLexInstruction(AbcMultiname property) : base(InstructionKind.GetLex)
        {
            Property = property;
        }
    }
}
