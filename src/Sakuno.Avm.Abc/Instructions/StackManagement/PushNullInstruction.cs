namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushNull)]
    public sealed partial class PushNullInstruction : AbcInstruction
    {
        internal PushNullInstruction() : base(InstructionKind.PushNull) { }
    }
}
