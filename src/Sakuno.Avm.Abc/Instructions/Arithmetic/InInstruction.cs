namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.In)]
    public sealed partial class InInstruction : AbcInstruction
    {
        internal InInstruction() : base(InstructionKind.In) { }
    }
}
