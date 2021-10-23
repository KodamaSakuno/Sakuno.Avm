namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CoerceA)]
    public sealed partial class CoerceAInstruction : AbcInstruction
    {
        internal CoerceAInstruction() : base(InstructionKind.CoerceA) { }
    }
}
