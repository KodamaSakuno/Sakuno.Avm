namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.Modulo)]
    public sealed partial class ModuloInstruction : AbcInstruction
    {
        internal ModuloInstruction() : base(InstructionKind.Modulo) { }
    }
}
