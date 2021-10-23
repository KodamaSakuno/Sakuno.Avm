namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Multiply)]
    public sealed partial class MultiplyInstruction : AbcInstruction
    {
        internal MultiplyInstruction() : base(InstructionKind.Multiply) { }
    }
}
