namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CallSuper)]
    public sealed partial class CallSuperInstruction : AbcInstruction
    {
        public AbcMultiname Multiname { get; }
        public int ArgumentCount { get; }

        internal CallSuperInstruction(AbcMultiname multiname, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.CallSuper)
        {
            Multiname = multiname;
            ArgumentCount = argumentCount;
        }
    }
}
