namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.BitNot)]
    public sealed partial class BitNotInstruction : AbcInstruction
    {
        internal BitNotInstruction() : base(InstructionKind.BitNot) { }
    }
}
