namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.RShift)]
    public sealed partial class RShiftInstruction : AbcInstruction
    {
        internal RShiftInstruction() : base(InstructionKind.RShift) { }
    }
}
