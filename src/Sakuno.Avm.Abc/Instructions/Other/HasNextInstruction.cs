namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.HasNext)]
    public sealed partial class HasNextInstruction : AbcInstruction
    {
        internal HasNextInstruction() : base(InstructionKind.HasNext) { }
    }
}
