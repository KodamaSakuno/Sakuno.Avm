namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CoerceS)]
    public sealed partial class CoerceSInstruction : AbcInstruction
    {
        internal CoerceSInstruction() : base(InstructionKind.CoerceS) { }
    }
}
