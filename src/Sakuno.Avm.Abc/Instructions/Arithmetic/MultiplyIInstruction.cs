namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.MultiplyI)]
    public sealed partial class MultiplyIInstruction : AbcInstruction
    {
        internal MultiplyIInstruction() : base(InstructionKind.MultiplyI) { }
    }
}
