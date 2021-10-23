namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NewObject)]
    public sealed partial class NewObjectInstruction : AbcInstruction
    {
        public int PropertyCount { get; }

        internal NewObjectInstruction([Argument(ArgumentKind.U30)] int propertyCount) : base(InstructionKind.NewObject)
        {
            PropertyCount = propertyCount;
        }
    }
}
