namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.LessEquals)]
    public sealed partial class LessEqualsInstruction : AbcInstruction
    {
        internal LessEqualsInstruction() : base(InstructionKind.LessEquals) { }
    }
}
