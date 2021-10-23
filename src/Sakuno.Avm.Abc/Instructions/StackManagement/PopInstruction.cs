namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Pop)]
    public sealed partial class PopInstruction : AbcInstruction
    {
        internal PopInstruction() : base(InstructionKind.Pop) { }
    }
}
