namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.HasNext2)]
    public sealed partial class HasNext2Instruction : AbcInstruction
    {
        internal HasNext2Instruction([Argument(ArgumentKind.U30)] int objectRegister, [Argument(ArgumentKind.U30)] int indexRegister) : base(InstructionKind.HasNext2) { }
    }
}
