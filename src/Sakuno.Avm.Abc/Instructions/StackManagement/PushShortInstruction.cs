namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushShort)]
    public sealed partial class PushShortInstruction : AbcInstruction
    {
        public int Value { get; }

        internal PushShortInstruction([Argument(ArgumentKind.U30)] int value) : base(InstructionKind.PushShort)
        {
            Value = value;
        }
    }
}
