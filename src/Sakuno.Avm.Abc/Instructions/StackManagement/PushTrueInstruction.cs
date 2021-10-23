namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushTrue)]
    public sealed partial class PushTrueInstruction : AbcInstruction
    {
        internal PushTrueInstruction() : base(InstructionKind.PushTrue) { }
    }
}
