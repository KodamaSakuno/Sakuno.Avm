namespace Sakuno.Avm.Abc.Instructions
{
    [Instruction(InstructionKind.DXNS)]
    public sealed partial class DXNSInstruction : AbcInstruction
    {
        public string XmlNamespace { get; }

        internal DXNSInstruction(string xmlNamespace) : base(InstructionKind.DXNS)
        {
            XmlNamespace = xmlNamespace;
        }
    }
}
