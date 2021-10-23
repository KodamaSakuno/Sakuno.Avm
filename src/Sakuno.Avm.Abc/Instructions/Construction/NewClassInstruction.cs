namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.NewClass)]
    public sealed partial class NewClassInstruction : AbcInstruction
    {
        public AbcClass Class { get; }

        internal NewClassInstruction(AbcClass @class) : base(InstructionKind.NewClass)
        {
            Class = @class;
        }
    }
}
