using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc.Instructions
{
    public sealed partial class LookupSwitchInstruction : AbcInstruction
    {
        public int DefaultJumpOffset { get; }
        public IReadOnlyList<int> CaseJumpOffsets { get; }

        internal LookupSwitchInstruction(int defaultJumpOffset, IReadOnlyList<int> caseJumpOffsets) : base(InstructionKind.LookupSwitch)
        {
            DefaultJumpOffset = defaultJumpOffset;
            CaseJumpOffsets = caseJumpOffsets ?? throw new ArgumentNullException(nameof(caseJumpOffsets));
        }
    }
}
