namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushUInt)]
    public sealed partial class PushUIntInstruction : AbcInstruction
    {
        public uint Value { get; }

        internal PushUIntInstruction(uint value) : base(InstructionKind.PushUInt)
        {
            Value = value;
        }
    }
}
