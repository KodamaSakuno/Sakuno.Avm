using System;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static AbcScript[] ReadScripts(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata, AbcClass[] classes)
        {
            var count = reader.ReadU30();

            if (count is 0)
                return Array.Empty<AbcScript>();

            var result = new AbcScript[count];

            for (var i = 0; i < result.Length; i++)
                result[i] = reader.ReadScript(constantPool, methods, metadata, classes);

            return result;
        }
        private static AbcScript ReadScript(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata, AbcClass[] classes)
        {
            var initializer = methods[reader.ReadU30()];
            var traits = reader.ReadTraits(constantPool, methods, metadata, classes);

            return new(initializer, traits);
        }
    }
}
