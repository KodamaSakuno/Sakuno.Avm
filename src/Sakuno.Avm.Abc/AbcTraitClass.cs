using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcTraitClass : AbcTrait
    {
        public int SlotId { get; }
        public AbcClass Class { get; }

        internal AbcTraitClass(AbcMultiname name, int slotId, AbcClass @class) : base(name)
        {
            SlotId = slotId;
            Class = @class ?? throw new ArgumentNullException(nameof(@class));
        }
    }
}
