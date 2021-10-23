namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushWith)]
    public sealed partial class PushWithInstruction : AbcInstruction
    {
        internal PushWithInstruction() : base(InstructionKind.PushWith) { }
    }
}
