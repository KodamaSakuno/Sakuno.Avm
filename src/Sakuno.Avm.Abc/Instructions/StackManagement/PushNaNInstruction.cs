namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushNaN)]
    public sealed partial class PushNaNInstruction : AbcInstruction
    {
        internal PushNaNInstruction() : base(InstructionKind.PushNaN) { }
    }
}
