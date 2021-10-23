namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Label)]
    public sealed partial class LabelInstruction : AbcInstruction
    {
        internal LabelInstruction() : base(InstructionKind.Label) { }
    }
}
