namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetGlobalScope)]
    public sealed partial class GetGlobalScopeInstruction : AbcInstruction
    {
        internal GetGlobalScopeInstruction() : base(InstructionKind.GetGlobalScope) { }
    }
}
