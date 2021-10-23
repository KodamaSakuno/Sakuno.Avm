using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcTraitFunction : AbcTrait
    {
        public int SlotId { get; }
        public AbcMethod Method { get; }

        internal AbcTraitFunction(AbcMultiname name, int slotId, AbcMethod method) : base(name)
        {
            SlotId = slotId;
            Method = method ?? throw new ArgumentNullException(nameof(method));
        }
    }
}
