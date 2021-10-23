namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Dup)]
    public sealed partial class DupInstruction : AbcInstruction
    {
        internal DupInstruction() : base(InstructionKind.Dup) { }
    }
}
