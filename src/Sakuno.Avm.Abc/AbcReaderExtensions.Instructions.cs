using Sakuno.Avm.Abc.Instructions;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static AbcInstruction ReadInstruction(this ref AbcReader reader, InstructionKind kind, ConstantPool constantPool, AbcMethod[] methods, AbcClass[] classes) =>
            kind is InstructionKind.LookupSwitch
                ? reader.ReadLookSwitchInstruction(constantPool, methods, classes)
                : reader.ReadInstructionCore(kind, constantPool, methods, classes);

        private static partial AbcInstruction ReadInstructionCore(this ref AbcReader reader, InstructionKind kind, ConstantPool constantPool, AbcMethod[] methods, AbcClass[] classes);
        private static LookupSwitchInstruction ReadLookSwitchInstruction(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcClass[] classes)
        {
            var defaultJumpOffset = reader.ReadS24();
            var caseJumpOffsetes = new int[reader.ReadU30() + 1];

            for (var i = 0; i < caseJumpOffsetes.Length; i++)
                caseJumpOffsetes[i] = reader.ReadS24();

            return new(defaultJumpOffset, caseJumpOffsetes);
        }
    }
}
