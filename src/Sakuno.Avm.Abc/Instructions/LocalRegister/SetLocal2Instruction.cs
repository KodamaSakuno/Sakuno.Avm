namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SetLocal2)]
    public sealed partial class SetLocal2Instruction : AbcInstruction
    {
        internal SetLocal2Instruction() : base(InstructionKind.SetLocal2) { }
    }
}
