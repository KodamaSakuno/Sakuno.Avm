using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcMetadata
    {
        public string Name { get; }
        public IReadOnlyDictionary<string, string> Items { get; }

        public AbcMetadata(string name, IReadOnlyDictionary<string, string> items)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }
    }
}
