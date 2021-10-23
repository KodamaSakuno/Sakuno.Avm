namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.URShift)]
    public sealed partial class URShiftInstruction : AbcInstruction
    {
        internal URShiftInstruction() : base(InstructionKind.URShift) { }
    }
}
