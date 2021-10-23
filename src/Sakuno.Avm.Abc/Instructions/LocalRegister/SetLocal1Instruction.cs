namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SetLocal1)]
    public sealed partial class SetLocal1Instruction : AbcInstruction
    {
        internal SetLocal1Instruction() : base(InstructionKind.SetLocal1) { }
    }
}
