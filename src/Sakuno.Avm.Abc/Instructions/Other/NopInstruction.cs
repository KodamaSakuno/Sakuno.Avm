namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Nop)]
    public sealed partial class NopInstruction : AbcInstruction
    {
        internal NopInstruction() : base(InstructionKind.Nop) { }
    }
}
