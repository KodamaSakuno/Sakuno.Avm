namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.AddI)]
    public sealed partial class AddIInstruction : AbcInstruction
    {
        internal AddIInstruction() : base(InstructionKind.AddI) { }
    }
}
