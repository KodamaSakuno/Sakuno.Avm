using System;

namespace Sakuno.Avm.Abc
{
    [Flags]
    internal enum InstanceFlags : byte
    {
        ClassSealed = 1,
        ClassFinal = 1 << 1,
        ClassInterface = 1 << 2,
        ClassProtectedNs = 1 << 3,
    }
}
