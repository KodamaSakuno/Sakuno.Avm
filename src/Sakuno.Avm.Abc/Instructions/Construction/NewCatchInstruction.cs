namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NewCatch)]
    public sealed partial class NewCatchInstruction : AbcInstruction
    {
        internal int ExceptionIndex { get; }
        public AbcExceptionBlock ExceptionBlock { get; internal set; } = default!;

        internal NewCatchInstruction([Argument(ArgumentKind.U30)] int exceptionIndex) : base(InstructionKind.NewCatch)
        {
            ExceptionIndex = exceptionIndex;
        }
    }
}
