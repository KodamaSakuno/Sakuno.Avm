namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Not)]
    public sealed partial class NotInstruction : AbcInstruction
    {
        internal NotInstruction() : base(InstructionKind.Not) { }
    }
}
