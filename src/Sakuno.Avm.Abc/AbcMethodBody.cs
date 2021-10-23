using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMethodBody
    {
        public int MaxStackCount { get; }

        public int LocalVariableCount { get; }

        public int InitialScopeDepth { get; }
        public int MaxScopeDepth { get; }

        public IReadOnlyList<AbcInstruction> Instructions { get; }
        public IReadOnlyList<AbcExceptionBlock> ExceptionBlocks { get; }
        public IReadOnlyList<AbcTrait> Traits { get; }

        internal AbcMethodBody(int maxStackCount, int localVariableCount, int intialScopeDepth, int maxScopeDepth, IReadOnlyList<AbcInstruction> instructions, IReadOnlyList<AbcExceptionBlock> exceptionBlocks, IReadOnlyList<AbcTrait> traits)
        {
            MaxStackCount = maxStackCount;
            LocalVariableCount = localVariableCount;
            InitialScopeDepth = intialScopeDepth;
            MaxScopeDepth = maxScopeDepth;

            Instructions = instructions ?? throw new ArgumentNullException(nameof(instructions));
            ExceptionBlocks = exceptionBlocks ?? throw new ArgumentNullException(nameof(exceptionBlocks));
            Traits = traits ?? throw new ArgumentNullException(nameof(traits));
        }
    }
}
