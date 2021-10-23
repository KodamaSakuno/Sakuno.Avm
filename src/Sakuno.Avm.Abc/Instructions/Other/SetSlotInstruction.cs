namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.SetSlot)]
    public sealed partial class SetSlotInstruction : AbcInstruction
    {
        public int SlotIndex { get; }

        internal SetSlotInstruction([Argument(ArgumentKind.U30)] int slotIndex) : base(InstructionKind.SetSlot)
        {
            SlotIndex = slotIndex;
        }
    }
}
