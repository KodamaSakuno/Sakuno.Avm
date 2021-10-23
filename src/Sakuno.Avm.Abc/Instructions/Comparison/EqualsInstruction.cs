namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Equals)]
    public sealed partial class EqualsInstruction : AbcInstruction
    {
        internal EqualsInstruction() : base(InstructionKind.Equals) { }
    }
}
