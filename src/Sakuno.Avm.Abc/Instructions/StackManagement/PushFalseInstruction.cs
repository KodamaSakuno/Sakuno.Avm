namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushFalse)]
    public sealed partial class PushFalseInstruction : AbcInstruction
    {
        internal PushFalseInstruction() : base(InstructionKind.PushFalse) { }
    }
}
