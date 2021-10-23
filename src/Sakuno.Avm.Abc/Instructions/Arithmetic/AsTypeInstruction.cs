namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.AsType)]
    public sealed partial class AsTypeInstruction : AbcInstruction
    {
        public AbcMultiname Type { get; }

        internal AsTypeInstruction(AbcMultiname type) : base(InstructionKind.AsType)
        {
            Type = type;
        }
    }
}
