namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.GetDescendants)]
    public sealed partial class GetDescendantsInstruction : AbcInstruction
    {
        public AbcMultiname Multiname { get; }

        internal GetDescendantsInstruction(AbcMultiname multiname) : base(InstructionKind.GetDescendants)
        {
            Multiname = multiname;
        }
    }
}
