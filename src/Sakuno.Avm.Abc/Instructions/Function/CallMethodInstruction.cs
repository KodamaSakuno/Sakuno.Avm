namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CallMethod)]
    public sealed partial class CallMethodInstruction : AbcInstruction
    {
        public AbcMethod Method { get; }
        public int ArgumentCount { get; }

        internal CallMethodInstruction(AbcMethod method, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.CallMethod)
        {
            Method = method;
            ArgumentCount = argumentCount;
        }
    }
}
