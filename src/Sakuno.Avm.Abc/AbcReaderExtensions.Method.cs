using System;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static AbcMethod[] ReadMethods(this ref AbcReader reader, ConstantPool constantPool)
        {
            var count = reader.ReadU30();

            if (count is 0)
                return Array.Empty<AbcMethod>();

            var result = new AbcMethod[count];

            for (var i = 0; i < result.Length; i++)
                result[i] = reader.ReadMethod(constantPool);

            return result;
        }
        private static AbcMethod ReadMethod(this ref AbcReader reader, ConstantPool constantPool)
        {
            var parameterCount = reader.ReadU30();
            var returnType = constantPool.GetMultinameOrDefault(reader.ReadU30(), AbcMultiname.Any);

            AbcMethodParameter[] parameters;

            if (parameterCount is 0)
                parameters = Array.Empty<AbcMethodParameter>();
            else
            {
                parameters = new AbcMethodParameter[parameterCount];

                for (var i = 0; i < parameters.Length; i++)
                    parameters[i] = new(constantPool.GetMultinameOrDefault(reader.ReadU30(), AbcMultiname.Any));
            }

            var nameIndex = reader.ReadU30();
            var name = nameIndex is 0 ? string.Empty : constantPool.GetString(nameIndex);

            var flags = reader.ReadU8<MethodFlags>();

            if (flags.HasFlag(MethodFlags.HasOptionalParameters))
            {
                var optionalParameterCount = reader.ReadU30();
                var offset = parameters.Length - optionalParameterCount;

                for (var i = 0; i < optionalParameterCount; i++)
                {
                    var value = reader.ReadU30();
                    var kind = reader.ReadU8<ConstantKind>();

                    parameters[i + offset].DefaultValue = constantPool.GetConstant(kind, value);
                }
            }

            if (flags.HasFlag(MethodFlags.HasParameterNames))
                for (var i = 0; i < parameterCount; i++)
                    parameters[i].Name = constantPool.GetString(reader.ReadU30());

            return new(name, returnType, parameters, flags);
        }
    }
}
