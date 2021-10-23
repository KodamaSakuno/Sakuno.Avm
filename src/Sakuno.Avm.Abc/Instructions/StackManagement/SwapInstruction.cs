namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Swap)]
    public sealed partial class SwapInstruction : AbcInstruction
    {
        internal SwapInstruction() : base(InstructionKind.Swap) { }
    }
}
