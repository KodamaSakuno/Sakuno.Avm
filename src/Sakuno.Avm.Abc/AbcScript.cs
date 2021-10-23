using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcScript
    {
        public AbcMethod Initializer { get; }
        public IReadOnlyList<AbcTrait> Traits { get; }

        public AbcScript(AbcMethod initializer, IReadOnlyList<AbcTrait> traits)
        {
            Initializer = initializer ?? throw new ArgumentNullException(nameof(initializer));
            Traits = traits ?? throw new ArgumentNullException(nameof(traits));
        }
    }
}
