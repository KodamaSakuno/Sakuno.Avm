namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.PushString)]
    public sealed partial class PushStringInstruction : AbcInstruction
    {
        public string Value { get; }

        internal PushStringInstruction(string value) : base(InstructionKind.PushString)
        {
            Value = value;
        }
    }
}
