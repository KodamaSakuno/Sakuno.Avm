namespace Sakuno.Avm.Abc
{
    internal enum ConstantKind : byte
    {
        Void = 0,
        Undefined = 0,
        UTF8String = 0x01,
        Integer = 0x03,
        UnsignedInteger = 0x04,
        Double = 0x06,
        False = 0x0A,
        True = 0x0B,
        Null = 0x0C,

        PrivateNamespace = 0x05,
        Namespace = 0x08,
        PackageNamespace = 0x16,
        PackageInternalNamespace = 0x17,
        ProtectedNamespace = 0x18,
        ExplicitNamespace = 0x19,
        StaticProtectedNamespace = 0x1A,
    }
}
