namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetLocal1)]
    public sealed partial class GetLocal1Instruction : AbcInstruction
    {
        internal GetLocal1Instruction() : base(InstructionKind.GetLocal1) { }
    }
}
