namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NextValue)]
    public sealed partial class NextValueInstruction : AbcInstruction
    {
        internal NextValueInstruction() : base(InstructionKind.NextValue) { }
    }
}
