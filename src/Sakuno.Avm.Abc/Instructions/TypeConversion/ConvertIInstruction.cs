namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ConvertI)]
    public sealed partial class ConvertIInstruction : AbcInstruction
    {
        internal ConvertIInstruction() : base(InstructionKind.ConvertI) { }
    }
}
