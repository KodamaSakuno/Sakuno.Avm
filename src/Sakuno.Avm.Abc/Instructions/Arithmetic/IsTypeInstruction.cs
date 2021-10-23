namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.IsType)]
    public sealed partial class IsTypeInstruction : AbcInstruction
    {
        public AbcMultiname Type { get; }

        internal IsTypeInstruction(AbcMultiname type) : base(InstructionKind.IsType)
        {
            Type = type;
        }
    }
}
