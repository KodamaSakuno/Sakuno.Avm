namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PopScope)]
    public sealed partial class PopScopeInstruction : AbcInstruction
    {
        internal PopScopeInstruction() : base(InstructionKind.PopScope) { }
    }
}
