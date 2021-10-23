using System;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static (AbcInstance[], AbcClass[]) ReadInstancesAndClasses(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata)
        {
            var count = reader.ReadU30();

            if (count is 0)
                return (Array.Empty<AbcInstance>(), Array.Empty<AbcClass>());

            var instances = new AbcInstance[count];
            var classes = new AbcClass[count];

            for (var i = 0; i < instances.Length; i++)
                instances[i] = reader.ReadInstance(constantPool, methods, metadata);

            for (var i = 0; i < classes.Length; i++)
                classes[i] = reader.ReadClass(constantPool, methods, metadata);

            return (instances, classes);
        }

        private static AbcInstance ReadInstance(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata)
        {
            var name = constantPool.GetMultiname(reader.ReadU30());
            var superNameIndex = reader.ReadU30();
            var superName = superNameIndex is 0 ? null : constantPool.GetMultiname(superNameIndex);
            var flags = reader.ReadU8<InstanceFlags>();
            var protectedNamespace = flags.HasFlag(InstanceFlags.ClassProtectedNs) ? constantPool.GetNamespace(reader.ReadU30()) : null;

            var interfaceCount = reader.ReadU30();

            AbcMultiname[] interfaces;

            if (interfaceCount is 0)
                interfaces = Array.Empty<AbcMultiname>();
            else
            {
                interfaces = new AbcMultiname[interfaceCount];

                for (var i = 0; i < interfaces.Length; i++)
                    interfaces[i] = constantPool.GetMultiname(reader.ReadU30());
            }

            var initializer = methods[reader.ReadU30()];
            var traits = reader.ReadTraits(constantPool, methods, metadata, Array.Empty<AbcClass>());

            return new((AbcMultinameQName)name, superName, protectedNamespace, interfaces, initializer, traits, flags);
        }
        private static AbcClass ReadClass(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata)
        {
            var initializer = methods[reader.ReadU30()];
            var traits = reader.ReadTraits(constantPool, methods, metadata, Array.Empty<AbcClass>());

            return new(initializer, traits);
        }
    }
}
