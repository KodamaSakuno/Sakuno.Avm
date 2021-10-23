namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ApplyType)]
    public sealed partial class ApplyTypeInstruction : AbcInstruction
    {
        public int ArgumentCount { get; }

        internal ApplyTypeInstruction([Argument(ArgumentKind.U30)] int argumentCount) : base(InstructionKind.ApplyType)
        {
            ArgumentCount = argumentCount;
        }
    }
}
