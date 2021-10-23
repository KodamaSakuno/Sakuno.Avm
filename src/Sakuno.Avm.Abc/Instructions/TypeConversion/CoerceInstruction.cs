namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Coerce)]
    public sealed partial class CoerceInstruction : AbcInstruction
    {
        public AbcMultiname Type { get; }

        internal CoerceInstruction(AbcMultiname type) : base(InstructionKind.Coerce)
        {
            Type = type;
        }
    }
}
