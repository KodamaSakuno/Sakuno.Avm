namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SubtractI)]
    public sealed partial class SubtractIInstruction : AbcInstruction
    {
        internal SubtractIInstruction() : base(InstructionKind.SubtractI) { }
    }
}
