namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Divide)]
    public sealed partial class DivideInstruction : AbcInstruction
    {
        internal DivideInstruction() : base(InstructionKind.Divide) { }
    }
}
