namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetScopeObject)]
    public sealed partial class GetScopeObjectInstruction : AbcInstruction
    {
        public int ScopeObjectIndex { get; }

        internal GetScopeObjectInstruction([Argument(ArgumentKind.U30)] int scopeObjectIndex) : base(InstructionKind.GetScopeObject)
        {
            ScopeObjectIndex = scopeObjectIndex;
        }
    }
}
