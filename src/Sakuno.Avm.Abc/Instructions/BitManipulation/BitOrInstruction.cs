namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.BitOr)]
    public sealed partial class BitOrInstruction : AbcInstruction
    {
        internal BitOrInstruction() : base(InstructionKind.BitOr) { }
    }
}
