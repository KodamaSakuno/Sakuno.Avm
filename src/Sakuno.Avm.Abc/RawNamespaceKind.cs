namespace Sakuno.Avm.Abc
{
    internal enum RawNamespaceKind : byte
    {
        PrivateNamespace = 0x05,
        Namespace = 0x08,
        PackageNamespace = 0x16,
        PackageInternalNamespace = 0x17,
        ProtectedNamespace = 0x18,
        ExplicitNamespace = 0x19,
        StaticProtectedNamespace = 0x1A,
    }
}
