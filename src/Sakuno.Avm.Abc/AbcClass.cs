using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcClass
    {
        public AbcMethod Initializer { get; }
        public IReadOnlyList<AbcTrait> Traits { get; }

#nullable disable
        public AbcInstance Instance { get; internal set; }
#nullable enable

        public AbcClass(AbcMethod initializer, IReadOnlyList<AbcTrait> traits)
        {
            Initializer = initializer ?? throw new ArgumentNullException(nameof(initializer));
            Traits = traits ?? throw new ArgumentNullException(nameof(traits));
        }
    }
}
