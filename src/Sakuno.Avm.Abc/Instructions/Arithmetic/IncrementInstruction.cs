namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Increment)]
    public sealed partial class IncrementInstruction : AbcInstruction
    {
        internal IncrementInstruction() : base(InstructionKind.Increment) { }
    }
}
