namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ConvertU)]
    public sealed partial class ConvertUInstruction : AbcInstruction
    {
        internal ConvertUInstruction() : base(InstructionKind.ConvertU) { }
    }
}
