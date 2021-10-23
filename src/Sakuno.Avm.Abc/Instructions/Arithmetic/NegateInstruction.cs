namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Negate)]
    public sealed partial class NegateInstruction : AbcInstruction
    {
        internal NegateInstruction() : base(InstructionKind.Negate) { }
    }
}
