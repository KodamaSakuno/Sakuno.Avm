namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushByte)]
    public sealed partial class PushByteInstruction : AbcInstruction
    {
        public byte Value { get; }

        internal PushByteInstruction(byte value) : base(InstructionKind.PushByte)
        {
            Value = value;
        }
    }
}
