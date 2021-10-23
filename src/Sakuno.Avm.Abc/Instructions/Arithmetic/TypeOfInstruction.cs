namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.TypeOf)]
    public sealed partial class TypeOfInstruction : AbcInstruction
    {
        internal TypeOfInstruction() : base(InstructionKind.TypeOf) { }
    }
}
