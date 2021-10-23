namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Decrement)]
    public sealed partial class DecrementInstruction : AbcInstruction
    {
        internal DecrementInstruction() : base(InstructionKind.Decrement) { }
    }
}
