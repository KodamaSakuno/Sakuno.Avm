using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    internal sealed class ConstantPool
    {
        private readonly IReadOnlyList<int> _integers;
        private readonly IReadOnlyList<uint> _unsignedIntegers;
        private readonly IReadOnlyList<double> _doubles;
        private readonly IReadOnlyList<string> _strings;
        private readonly IReadOnlyList<AbcNamespace> _namespaces;
        private readonly IReadOnlyList<AbcNamespaceSet> _namespaceSets;
        private readonly IReadOnlyList<AbcMultiname> _multinames;

        internal ConstantPool(int[] integers,
            uint[] unsignedIntegers,
            double[] doubles,
            string[] strings,
            AbcNamespace[] namespaces,
            AbcNamespaceSet[] namespaceSets,
            AbcMultiname[] multinames)
        {
            _integers = integers;
            _unsignedIntegers = unsignedIntegers;
            _doubles = doubles;
            _strings = strings;
            _namespaces = namespaces;
            _namespaceSets = namespaceSets;
            _multinames = multinames;
        }

        public int GetInteger(int index) => _integers[index];
        public uint GetUnsignedInteger(int index) => _unsignedIntegers[index];
        public double GetDouble(int index) => _doubles[index];
        public string GetString(int index) => _strings[index];
        public AbcNamespace GetNamespace(int index) => _namespaces[index];
        public AbcNamespaceSet GetNamespaceSet(int index) => _namespaceSets[index];
        public AbcMultiname GetMultiname(int index) => _multinames[index];

        public AbcMultiname GetMultinameOrDefault(int index, AbcMultiname defaultValue)
        {
            if (index is 0)
                return defaultValue ?? throw new ArgumentNullException(nameof(defaultValue));

            return _multinames[index];
        }

        public AbcConstant GetConstant(ConstantKind kind, int index) => kind switch
        {
            ConstantKind.Undefined => AbcConstant.Undefined,
            ConstantKind.UTF8String => _strings[index],
            ConstantKind.Integer => _integers[index],
            ConstantKind.UnsignedInteger => _unsignedIntegers[index],
            ConstantKind.Double => _doubles[index],
            ConstantKind.False => AbcConstant.False,
            ConstantKind.True => AbcConstant.True,
            ConstantKind.Null => AbcConstant.Null,
            ConstantKind.Namespace => _namespaces[index],

            _ => throw new ArgumentException(null, nameof(kind)),
        };
    }
}
