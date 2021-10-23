namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Add)]
    public sealed partial class AddInstruction : AbcInstruction
    {
        internal AddInstruction() : base(InstructionKind.Add) { }
    }
}
