namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Debug)]
    public sealed partial class DebugInstruction : AbcInstruction
    {
        internal DebugInstruction(byte type, string @string, byte register, [Argument(ArgumentKind.U30)] int reserved) : base(InstructionKind.Debug) { }
    }
}
