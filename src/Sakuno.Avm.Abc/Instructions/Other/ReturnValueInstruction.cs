namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ReturnValue)]
    public sealed partial class ReturnValueInstruction : AbcInstruction
    {
        internal ReturnValueInstruction() : base(InstructionKind.ReturnValue) { }
    }
}
