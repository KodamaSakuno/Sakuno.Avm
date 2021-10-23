namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.CallStatic)]
    public sealed partial class CallStaticInstruction : AbcInstruction
    {
        public AbcMethod Method { get; }
        public int ArgumentCount { get; }

        internal CallStaticInstruction(AbcMethod method, [Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.CallStatic)
        {
            Method = method;
            ArgumentCount = argumentCount;
        }
    }
}
