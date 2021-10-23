namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NewFunction)]
    public sealed partial class NewFunctionInstruction : AbcInstruction
    {
        public AbcMethod Method { get; }

        internal NewFunctionInstruction(AbcMethod method) : base(InstructionKind.NewFunction)
        {
            Method = method;
        }
    }
}
