using System;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcTraitSetter : AbcTrait
    {
        public int DispId { get; }
        public AbcMethod Method { get; }

        internal AbcTraitSetter(AbcMultiname name, int dispId, AbcMethod method) : base(name)
        {
            DispId = dispId;
            Method = method ?? throw new ArgumentNullException(nameof(method));
        }
    }
}
