namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushUndefined)]
    public sealed partial class PushUndefinedInstruction : AbcInstruction
    {
        internal PushUndefinedInstruction() : base(InstructionKind.PushUndefined) { }
    }
}
