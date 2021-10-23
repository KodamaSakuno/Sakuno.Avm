namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ReturnVoid)]
    public sealed partial class ReturnVoidInstruction : AbcInstruction
    {
        internal ReturnVoidInstruction() : base(InstructionKind.ReturnVoid) { }
    }
}
