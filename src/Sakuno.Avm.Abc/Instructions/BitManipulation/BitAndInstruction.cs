namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.BitAnd)]
    public sealed partial class BitAndInstruction : AbcInstruction
    {
        internal BitAndInstruction() : base(InstructionKind.BitAnd) { }
    }
}
