using Sakuno.Avm.Abc.Instructions;
using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static void ReadMethodBodies(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata, AbcClass[] classes)
        {
            var count = reader.ReadU30();

            for (var i = 0; i < count; i++)
                reader.ReadMethodBody(constantPool, methods, metadata, classes);
        }
        private static void ReadMethodBody(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata, AbcClass[] classes)
        {
            var method = methods[reader.ReadU30()];
            var maxStack = reader.ReadU30();
            var localCount = reader.ReadU30();
            var initScopeDepth = reader.ReadU30();
            var maxScopeDepth = reader.ReadU30();
            var codeLength = reader.ReadU30();

            var instructions = new List<AbcInstruction>();
            List<NewCatchInstruction>? newCatchInstructions = null;

            var offset = 0;

            while (offset < codeLength)
            {
                var currentBytesRead = reader.Position;

                var instruction = reader.ReadInstruction(offset, constantPool, methods, classes);

                instructions.Add(instruction);

                if (instruction is NewCatchInstruction newCatchInstruction)
                {
                    newCatchInstructions ??= new List<NewCatchInstruction>();
                    newCatchInstructions.Add(newCatchInstruction);
                }

                offset += reader.Position - currentBytesRead;
            }

            var exceptionCount = reader.ReadU30();

            AbcExceptionBlock[] exceptionBlocks;

            if (exceptionCount is 0)
                exceptionBlocks = Array.Empty<AbcExceptionBlock>();
            else
            {
                exceptionBlocks = new AbcExceptionBlock[exceptionCount];

                for (var i = 0; i < exceptionBlocks.Length; i++)
                {
                    var from = reader.ReadU30();
                    var to = reader.ReadU30();
                    var target = reader.ReadU30();
                    var execeptionType = constantPool.GetMultinameOrDefault(reader.ReadU30(), AbcMultiname.Any);
                    var variableName = constantPool.GetMultiname(reader.ReadU30());

                    exceptionBlocks[i] = new AbcExceptionBlock(from, to, target, execeptionType, variableName);
                }
            }

            if (newCatchInstructions is not null)
                foreach (var instruction in newCatchInstructions)
                    instruction.ExceptionBlock = exceptionBlocks[instruction.ExceptionIndex];

            var traits = reader.ReadTraits(constantPool, methods, metadata, classes);

            method.Body = new(maxStack, localCount, initScopeDepth, maxScopeDepth, instructions.ToArray(), exceptionBlocks, traits);
        }
        private static AbcInstruction ReadInstruction(this ref AbcReader reader, int offset, ConstantPool constantPool, AbcMethod[] methods, AbcClass[] classes)
        {
            var code = reader.ReadU8<InstructionKind>();
            var result = reader.ReadInstruction(code, constantPool, methods, classes);

            result.Offset = offset;

            return result;
        }
    }
}
