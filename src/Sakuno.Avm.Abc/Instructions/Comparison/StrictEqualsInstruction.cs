namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.StrictEquals)]
    public sealed partial class StrictEqualsInstruction : AbcInstruction
    {
        internal StrictEqualsInstruction() : base(InstructionKind.StrictEquals) { }
    }
}
