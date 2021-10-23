namespace Sakuno.Avm.Abc
{
    public abstract class AbcInstruction
    {
        public InstructionKind Kind { get; }

        public int Offset { get; internal set; }

        private protected AbcInstruction(InstructionKind kind)
        {
            Kind = kind;
        }
    }
}
