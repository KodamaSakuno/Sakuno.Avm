namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.LessThan)]
    public sealed partial class LessThanInstruction : AbcInstruction
    {
        internal LessThanInstruction() : base(InstructionKind.LessThan) { }
    }
}
