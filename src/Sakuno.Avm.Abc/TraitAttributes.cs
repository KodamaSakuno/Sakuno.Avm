using System;

namespace Sakuno.Avm.Abc
{
    [Flags]
    internal enum TraitAttributes
    {
        Final = 1,
        Override = 1 << 1,
        Metadata = 1 << 2,
    }
}
