namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NextName)]
    public sealed partial class NextNameInstruction : AbcInstruction
    {
        internal NextNameInstruction() : base(InstructionKind.NextName) { }
    }
}
