using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public abstract class AbcTrait
    {
        public AbcMultiname Name { get; }
#nullable disable
        public IReadOnlyList<AbcMetadata> Metadata { get; internal set; }
#nullable enable

        private protected AbcTrait(AbcMultiname name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
