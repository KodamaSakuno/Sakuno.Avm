namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NewActivation)]
    public sealed partial class NewActivationInstruction : AbcInstruction
    {
        internal NewActivationInstruction() : base(InstructionKind.NewActivation) { }
    }
}
