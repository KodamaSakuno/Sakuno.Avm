using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcTraitSlot : AbcTrait
    {
        public int SlotId { get; }
        public AbcMultiname TypeName { get; }
        public AbcConstant? Value { get; }

        internal AbcTraitSlot(AbcMultiname name, int slotId, AbcMultiname typeName, AbcConstant? value) : base(name)
        {
            SlotId = slotId;
            TypeName = typeName ?? throw new ArgumentNullException(nameof(typeName));
            Value = value;
        }
    }
}
