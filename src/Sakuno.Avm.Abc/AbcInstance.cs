using System;
using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    public sealed class AbcInstance
    {
        public AbcMultinameQName Name { get; }

        public AbcMultiname? BaseClass { get; }
        public AbcNamespace? ProtectedNamespace { get; }
        public IReadOnlyList<AbcMultiname> ImplementedInterfaces { get; }

        public AbcMethod Initializer { get; }

        public IReadOnlyList<AbcTrait> Traits { get; }

        public bool IsSealed { get; }
        public bool IsFinal { get; }
        public bool IsInterface { get; }

        internal AbcInstance(AbcMultinameQName name, AbcMultiname? baseClass, AbcNamespace? protectedNamespace, IReadOnlyList<AbcMultiname> implementedInterfaces, AbcMethod initializer, IReadOnlyList<AbcTrait> traits, InstanceFlags flags)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BaseClass = baseClass;
            ProtectedNamespace = protectedNamespace;
            ImplementedInterfaces = implementedInterfaces ?? throw new ArgumentNullException(nameof(implementedInterfaces));

            Initializer = initializer ?? throw new ArgumentNullException(nameof(initializer));

            Traits = traits ?? throw new ArgumentNullException(nameof(traits));

            IsSealed = flags.HasFlag(InstanceFlags.ClassSealed);
            IsFinal = flags.HasFlag(InstanceFlags.ClassFinal);
            IsInterface = flags.HasFlag(InstanceFlags.ClassInterface);
        }
    }
}
