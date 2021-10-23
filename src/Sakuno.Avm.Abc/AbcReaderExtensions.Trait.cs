using System;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static AbcTrait[] ReadTraits(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata, AbcClass[] classes)
        {
            var count = reader.ReadU30();

            if (count is 0)
                return Array.Empty<AbcTrait>();

            var result = new AbcTrait[count];

            for (var i = 0; i < count; i++)
                result[i] = reader.ReadTrait(constantPool, methods, metadata, classes);

            return result;
        }
        private static AbcTrait ReadTrait(this ref AbcReader reader, ConstantPool constantPool, AbcMethod[] methods, AbcMetadata[] metadata, AbcClass[] classes)
        {
            var name = constantPool.GetMultiname(reader.ReadU30());
            var kindAndAttributes = reader.ReadU8();
            var kind = (TraitKind)(kindAndAttributes & 0xF);
            var attributes = (TraitAttributes)(kindAndAttributes >> 4);

            var result = kind switch
            {
                TraitKind.Slot or
                TraitKind.Const => reader.ReadSlotOrConstTrait(kind, name, constantPool),
                TraitKind.Method or
                TraitKind.Getter or
                TraitKind.Setter => reader.ReadMethodTrait(kind, name, methods),
                TraitKind.Class => reader.ReadClassTrait(name, classes),
                TraitKind.Function => reader.ReadFunctionTrait(name, methods),

                _ => throw new InvalidOperationException(),
            };

            AbcMetadata[] metadataEntries;

            if (!attributes.HasFlag(TraitAttributes.Metadata))
                metadataEntries = Array.Empty<AbcMetadata>();
            else
            {
                metadataEntries = new AbcMetadata[reader.ReadU30()];

                for (var i = 0; i < metadataEntries.Length; i++)
                    metadataEntries[i] = metadata[reader.ReadU30()];
            }

            result.Metadata = metadataEntries;

            return result;
        }
        private static AbcTrait ReadSlotOrConstTrait(this ref AbcReader reader, TraitKind kind, AbcMultiname name, ConstantPool constantPool)
        {
            var slotId = reader.ReadU30();
            var typeName = constantPool.GetMultinameOrDefault(reader.ReadU30(), AbcMultiname.Any);
            var valueIndex = reader.ReadU30();

            AbcConstant? value = null;

            if (valueIndex is not 0)
                value = constantPool.GetConstant(reader.ReadU8<ConstantKind>(), valueIndex);

            return kind switch
            {
                TraitKind.Slot => new AbcTraitSlot(name, slotId, typeName, value),
                TraitKind.Const => new AbcTraitConst(name, slotId, typeName, value),

                _ => throw new ArgumentException(null, nameof(kind)),
            };
        }
        private static AbcTrait ReadMethodTrait(this ref AbcReader reader, TraitKind kind, AbcMultiname name, AbcMethod[] methods)
        {
            var dispId = reader.ReadU30();
            var method = methods[reader.ReadU30()];

            return kind switch
            {
                TraitKind.Method => new AbcTraitMethod(name, dispId, method),
                TraitKind.Getter => new AbcTraitGetter(name, dispId, method),
                TraitKind.Setter => new AbcTraitSetter(name, dispId, method),

                _ => throw new ArgumentException(null, nameof(kind)),
            };
        }
        private static AbcTraitClass ReadClassTrait(this ref AbcReader reader, AbcMultiname name, AbcClass[] classes) =>
            new(name, reader.ReadU30(), classes[reader.ReadU30()]);
        private static AbcTraitFunction ReadFunctionTrait(this ref AbcReader reader, AbcMultiname name, AbcMethod[] methods) =>
            new(name, reader.ReadU30(), methods[reader.ReadU30()]);
    }
}
