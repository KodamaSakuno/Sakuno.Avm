namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetLocal2)]
    public sealed partial class GetLocal2Instruction : AbcInstruction
    {
        internal GetLocal2Instruction() : base(InstructionKind.GetLocal2) { }
    }
}
