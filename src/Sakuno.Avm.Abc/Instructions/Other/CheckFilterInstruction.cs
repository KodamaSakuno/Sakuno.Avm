namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CheckFilter)]
    public sealed partial class CheckFilterInstruction : AbcInstruction
    {
        internal CheckFilterInstruction() : base(InstructionKind.CheckFilter) { }
    }
}
