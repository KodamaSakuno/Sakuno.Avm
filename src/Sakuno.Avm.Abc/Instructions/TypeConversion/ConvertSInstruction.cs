namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ConvertS)]
    public sealed partial class ConvertSInstruction : AbcInstruction
    {
        internal ConvertSInstruction() : base(InstructionKind.ConvertS) { }
    }
}
