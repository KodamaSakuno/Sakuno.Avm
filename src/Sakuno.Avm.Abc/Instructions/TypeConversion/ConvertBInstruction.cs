namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ConvertB)]
    public sealed partial class ConvertBInstruction : AbcInstruction
    {
        internal ConvertBInstruction() : base(InstructionKind.ConvertB) { }
    }
}
