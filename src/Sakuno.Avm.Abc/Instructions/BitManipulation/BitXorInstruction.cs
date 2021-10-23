namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.BitXor)]
    public sealed partial class BitXorInstruction : AbcInstruction
    {
        internal BitXorInstruction() : base(InstructionKind.BitXor) { }
    }
}
