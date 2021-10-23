namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.DebugLine)]
    public sealed partial class DebugLineInstruction : AbcInstruction
    {
        public int LineNumber { get; }

        internal DebugLineInstruction([Argument(ArgumentKind.U30)] int lineNumber) : base(InstructionKind.DebugLine)
        {
            LineNumber = lineNumber;
        }
    }
}
