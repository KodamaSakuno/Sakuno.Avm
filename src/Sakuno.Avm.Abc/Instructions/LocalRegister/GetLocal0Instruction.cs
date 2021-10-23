namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetLocal0)]
    public sealed partial class GetLocal0Instruction : AbcInstruction
    {
        internal GetLocal0Instruction() : base(InstructionKind.GetLocal0) { }
    }
}
