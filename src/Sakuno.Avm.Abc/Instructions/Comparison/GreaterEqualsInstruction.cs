namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GreaterEquals)]
    public sealed partial class GreaterEqualsInstruction : AbcInstruction
    {
        internal GreaterEqualsInstruction() : base(InstructionKind.GreaterEquals) { }
    }
}
