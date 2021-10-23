namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NegateI)]
    public sealed partial class NegateIInstruction : AbcInstruction
    {
        internal NegateIInstruction() : base(InstructionKind.NegateI) { }
    }
}
