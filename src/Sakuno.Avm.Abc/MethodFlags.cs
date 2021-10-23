using System;

namespace Sakuno.Avm.Abc
{
    [Flags]
    internal enum MethodFlags
    {
        NeedArguments = 1,
        NeedActivation = 1 << 1,
        NeedReset = 1 << 2,
        HasOptionalParameters = 1 << 3,
        IgnoreRest = 1 << 4,
        Native = 1 << 5,
        SetDxns = 1 << 6,
        HasParameterNames = 1 << 7,
    }
}
