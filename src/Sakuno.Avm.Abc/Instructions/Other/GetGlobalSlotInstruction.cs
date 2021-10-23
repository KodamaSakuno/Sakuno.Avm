namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetGlobalSlot)]
    public sealed partial class GetGlobalSlotInstruction : AbcInstruction
    {
        public int SlotIndex { get; }

        internal GetGlobalSlotInstruction([Argument(ArgumentKind.U30)] int slotIndex) : base(InstructionKind.GetGlobalSlot)
        {
            SlotIndex = slotIndex;
        }
    }
}
