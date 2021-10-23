namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushScope)]
    public sealed partial class PushScopeInstruction : AbcInstruction
    {
        internal PushScopeInstruction() : base(InstructionKind.PushScope) { }
    }
}
