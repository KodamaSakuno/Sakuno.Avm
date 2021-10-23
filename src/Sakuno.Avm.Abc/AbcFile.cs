using System;
using System.Buffers.Binary;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcFile
    {
        public IReadOnlyList<AbcMethod> Methods { get; }
        public IReadOnlyList<AbcInstance> Instances { get; }
        public IReadOnlyList<AbcClass> Classes { get; }
        public IReadOnlyList<AbcScript> Scripts { get; }

        private AbcFile(IReadOnlyList<AbcMethod> methods, IReadOnlyList<AbcInstance> instances, IReadOnlyList<AbcClass> classes, IReadOnlyList<AbcScript> scripts)
        {
            Methods = methods ?? throw new ArgumentNullException(nameof(methods));
            Instances = instances ?? throw new ArgumentNullException(nameof(instances));
            Classes = classes ?? throw new ArgumentNullException(nameof(classes));
            Scripts = scripts ?? throw new ArgumentNullException(nameof(scripts));
        }

        public static AbcFile Load(ReadOnlySpan<byte> bytes)
        {
            var minorVersion = BinaryPrimitives.ReadInt16LittleEndian(bytes);
            var majorVersion = BinaryPrimitives.ReadInt16LittleEndian(bytes[2..]);

            if ((majorVersion, minorVersion) is not (46, 16))
                throw new InvalidOperationException("This library is designed for ABC file with major version 46, minor version 16");

            var reader = new AbcReader(bytes[4..]);

            var constantPool = reader.ReadConstantPool();
            var methods = reader.ReadMethods(constantPool);
            var metadata = reader.ReadMetadata(constantPool);
            var (instances, classes) = reader.ReadInstancesAndClasses(constantPool, methods, metadata);
            var scripts = reader.ReadScripts(constantPool, methods, metadata, classes);

            reader.ReadMethodBodies(constantPool, methods, metadata, classes);

            return new(methods, instances, classes, scripts);
        }
    }
}
