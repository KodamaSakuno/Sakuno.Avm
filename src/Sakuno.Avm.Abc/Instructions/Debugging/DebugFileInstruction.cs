namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.DebugFile)]
    public sealed partial class DebugFileInstruction : AbcInstruction
    {
        public string SourceFile { get; }

        internal DebugFileInstruction(string sourceFile) : base(InstructionKind.DebugFile)
        {
            SourceFile = sourceFile;
        }
    }
}
