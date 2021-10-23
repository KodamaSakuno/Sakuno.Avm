namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.InstanceOf)]
    public sealed partial class InstanceOfInstruction : AbcInstruction
    {
        internal InstanceOfInstruction() : base(InstructionKind.InstanceOf) { }
    }
}
