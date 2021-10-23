namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Kill)]
    public sealed partial class KillInstruction : AbcInstruction
    {
        public int RegisterIndex { get; }

        internal KillInstruction([Argument(ArgumentKind.U30)] int registerIndex) : base(InstructionKind.Kill)
        {
            RegisterIndex = registerIndex;
        }
    }
}
