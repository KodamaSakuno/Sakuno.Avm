namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CallSuperVoid)]
    public sealed partial class CallSuperVoidInstruction : AbcInstruction
    {
        public AbcMultiname Multiname { get; }
        public int ArgumentCount { get; }

        internal CallSuperVoidInstruction(AbcMultiname multiname, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.CallSuperVoid)
        {
            Multiname = multiname;
            ArgumentCount = argumentCount;
        }
    }
}
