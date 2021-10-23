namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GreaterThan)]
    public sealed partial class GreaterThanInstruction : AbcInstruction
    {
        internal GreaterThanInstruction() : base(InstructionKind.GreaterThan) { }
    }
}
