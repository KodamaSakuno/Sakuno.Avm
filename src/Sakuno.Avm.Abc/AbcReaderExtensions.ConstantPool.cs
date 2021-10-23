using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static ConstantPool ReadConstantPool(this ref AbcReader reader)
        {
            var integers = new int[reader.ReadU30()];

            for (var i = 1; i < integers.Length; i++)
                integers[i] = reader.ReadS32();

            var unsignedIntegers = new uint[reader.ReadU30()];

            for (var i = 1; i < unsignedIntegers.Length; i++)
                unsignedIntegers[i] = reader.ReadU32();

            var doubles = new double[reader.ReadU30()];

            for (var i = 1; i < doubles.Length; i++)
                doubles[i] = reader.ReadD64();

            var strings = new string[reader.ReadU30()];

            for (var i = 1; i < strings.Length; i++)
                strings[i] = reader.ReadString();

            var namespaces = new AbcNamespace[reader.ReadU30()];

            for (var i = 1; i < namespaces.Length; i++)
            {
                var kind = reader.ReadU8<RawNamespaceKind>();
                var name = strings[reader.ReadU30()];

                namespaces[i] = new(kind switch
                {
                    RawNamespaceKind.PrivateNamespace => NamespaceKind.PrivateNamespace,
                    RawNamespaceKind.Namespace => NamespaceKind.Namespace,
                    RawNamespaceKind.PackageNamespace => NamespaceKind.PackageNamespace,
                    RawNamespaceKind.PackageInternalNamespace => NamespaceKind.PackageInternalNamespace,
                    RawNamespaceKind.ProtectedNamespace => NamespaceKind.ProtectedNamespace,
                    RawNamespaceKind.ExplicitNamespace => NamespaceKind.ExplicitNamespace,
                    RawNamespaceKind.StaticProtectedNamespace => NamespaceKind.StaticProtectedNamespace,

                    _ => throw new FormatException("Unknown namespace kind: " + kind),
                }, name);
            }

            var namespaceSets = new AbcNamespaceSet[reader.ReadU30()];

            for (var i = 1; i < namespaceSets.Length; i++)
            {
                var innerNamespaces = new AbcNamespace[reader.ReadU30()];

                for (var j = 0; j < innerNamespaces.Length; j++)
                    innerNamespaces[j] = namespaces[reader.ReadU30()];

                namespaceSets[i] = new(innerNamespaces);
            }

            var multinames = new AbcMultiname[reader.ReadU30()];
            var rawTypeNames = new List<(int, int, int[])>();

            for (var i = 1; i < multinames.Length; i++)
            {
                var kind = reader.ReadU8<RawMultinameKind>();

                multinames[i] = kind switch
                {
                    RawMultinameKind.QName => reader.ReadMultinameQName(MultinameKind.QName, namespaces, strings),
                    RawMultinameKind.QNameA => reader.ReadMultinameQName(MultinameKind.QNameA, namespaces, strings),
                    RawMultinameKind.RTQName => reader.ReadMultinameRTQName(MultinameKind.RTQName, strings),
                    RawMultinameKind.RTQNameA => reader.ReadMultinameRTQName(MultinameKind.RTQNameA, strings),
                    RawMultinameKind.RTQNameL => AbcMultinameRTQNameL.Instance,
                    RawMultinameKind.RTQNameLA => AbcMultinameRTQNameL.AttributeInstance,
                    RawMultinameKind.Multiname => reader.ReadMultinameMultiname(MultinameKind.Multiname, strings, namespaceSets),
                    RawMultinameKind.MultinameA => reader.ReadMultinameMultiname(MultinameKind.MultinameA, strings, namespaceSets),
                    RawMultinameKind.MultinameL => reader.ReadMultinameMultinameL(MultinameKind.MultinameL, namespaceSets),
                    RawMultinameKind.MultinameLA => reader.ReadMultinameMultinameL(MultinameKind.MultinameLA, namespaceSets),
                    RawMultinameKind.TypeName => reader.ReadMultinameTypeName(i, rawTypeNames),

                    _ => throw new FormatException("Unknown multiname kind: " + kind),
                };
            }

            foreach (var (index, nameIndex, parameterIndexes) in rawTypeNames)
            {
                var name = multinames[nameIndex];
                var parameters = new AbcMultiname[parameterIndexes.Length];

                for (var i = 0; i < parameterIndexes.Length; i++)
                    parameters[i] = multinames[parameterIndexes[i]];

                multinames[index] = new AbcMultinameTypeName(name, parameters);
            }

            return new(integers, unsignedIntegers, doubles, strings, namespaces, namespaceSets, multinames);
        }
        private static AbcMultinameQName ReadMultinameQName(this ref AbcReader reader, MultinameKind kind, AbcNamespace[] namespaces, string[] strings) =>
            new(kind, namespaces[reader.ReadU30()], strings[reader.ReadU30()]);
        private static AbcMultinameRTQName ReadMultinameRTQName(this ref AbcReader reader, MultinameKind kind, string[] strings) =>
            new(kind, strings[reader.ReadU30()]);
        private static AbcMultinameMultiname ReadMultinameMultiname(this ref AbcReader reader, MultinameKind kind, string[] strings, AbcNamespaceSet[] namespaceSets) =>
            new(kind, strings[reader.ReadU30()], namespaceSets[reader.ReadU30()]);
        private static AbcMultinameMultinameL ReadMultinameMultinameL(this ref AbcReader reader, MultinameKind kind, AbcNamespaceSet[] namespaceSets) =>
            new(kind, namespaceSets[reader.ReadU30()]);
        private static AbcMultiname ReadMultinameTypeName(this ref AbcReader reader, int index, List<(int, int, int[])> rawTypeNames)
        {
            var nameIndex = reader.ReadU30();
            var parameters = new int[reader.ReadU30()];

            for (var i = 0; i < parameters.Length; i++)
                parameters[i] = reader.ReadU30();

            rawTypeNames.Add((index, nameIndex, parameters));

            return null!;
        }
    }
}
