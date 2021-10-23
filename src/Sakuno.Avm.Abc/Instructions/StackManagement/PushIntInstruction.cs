namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushInt)]
    public sealed partial class PushIntInstruction : AbcInstruction
    {
        public int Value { get; }

        internal PushIntInstruction(int value) : base(InstructionKind.PushInt)
        {
            Value = value;
        }
    }
}
