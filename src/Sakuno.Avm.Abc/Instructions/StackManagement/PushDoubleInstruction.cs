namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushDouble)]
    public sealed partial class PushDoubleInstruction : AbcInstruction
    {
        public double Value { get; }

        internal PushDoubleInstruction(double value) : base(InstructionKind.PushDouble)
        {
            Value = value;
        }
    }
}
