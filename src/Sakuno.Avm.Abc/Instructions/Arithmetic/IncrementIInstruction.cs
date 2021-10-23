namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IncrementI)]
    public sealed partial class IncrementIInstruction : AbcInstruction
    {
        internal IncrementIInstruction() : base(InstructionKind.IncrementI) { }
    }
}
