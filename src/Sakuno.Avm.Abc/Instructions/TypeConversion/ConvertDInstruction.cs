namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.ConvertD)]
    public sealed partial class ConvertDInstruction : AbcInstruction
    {
        internal ConvertDInstruction() : base(InstructionKind.ConvertD) { }
    }
}
