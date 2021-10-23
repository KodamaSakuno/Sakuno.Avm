namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NewArray)]
    public sealed partial class NewArrayInstruction : AbcInstruction
    {
        public int Length { get; }

        internal NewArrayInstruction([Argument(ArgumentKind.U30)] int length) : base(InstructionKind.NewArray)
        {
            Length = length;
        }
    }
}
