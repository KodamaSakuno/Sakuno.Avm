namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SetGlobalSlot)]
    public sealed partial class SetGlobalSlotInstruction : AbcInstruction
    {
        public int SlotIndex { get; }

        internal SetGlobalSlotInstruction([Argument(ArgumentKind.U30)] int slotIndex) : base(InstructionKind.SetGlobalSlot)
        {
            SlotIndex = slotIndex;
        }
    }
}
