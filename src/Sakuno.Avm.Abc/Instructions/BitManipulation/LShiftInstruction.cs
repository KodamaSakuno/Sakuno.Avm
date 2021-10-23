namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.LShift)]
    public sealed partial class LShiftInstruction : AbcInstruction
    {
        internal LShiftInstruction() : base(InstructionKind.LShift) { }
    }
}
