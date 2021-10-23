namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Throw)]
    public sealed partial class ThrowInstruction : AbcInstruction
    {
        internal ThrowInstruction() : base(InstructionKind.Throw) { }
    }
}
