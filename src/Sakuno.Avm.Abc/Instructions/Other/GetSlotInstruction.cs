namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetSlot)]
    public sealed partial class GetSlotInstruction : AbcInstruction
    {
        public int SlotIndex { get; }

        internal GetSlotInstruction([Argument(ArgumentKind.U30)] int slotIndex) : base(InstructionKind.GetSlot)
        {
            SlotIndex = slotIndex;
        }
    }
}
