namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Subtract)]
    public sealed partial class SubtractInstruction : AbcInstruction
    {
        internal SubtractInstruction() : base(InstructionKind.Subtract) { }
    }
}
