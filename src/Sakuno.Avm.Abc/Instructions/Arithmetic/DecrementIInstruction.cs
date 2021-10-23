namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.DecrementI)]
    public sealed partial class DecrementIInstruction : AbcInstruction
    {
        internal DecrementIInstruction() : base(InstructionKind.DecrementI) { }
    }
}
