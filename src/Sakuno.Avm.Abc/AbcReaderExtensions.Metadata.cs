using System.Collections.Generic;

namespace Sakuno.Avm.Abc
{
    internal static partial class AbcReaderExtensions
    {
        public static AbcMetadata[] ReadMetadata(this ref AbcReader reader, ConstantPool constantPool)
        {
            var result = new AbcMetadata[reader.ReadU30()];

            for (var i = 0; i < result.Length; i++)
            {
                var name = constantPool.GetString(reader.ReadU30());
                var itemCount = reader.ReadU30();

                var items = new SortedList<string, string>(itemCount);

                for (var j = 0; j < itemCount; j++)
                {
                    var key = constantPool.GetString(reader.ReadU30()) ?? string.Empty;
                    var value = constantPool.GetString(reader.ReadU30());

                    items.Add(key, value);
                }

                result[i] = new(name, items);
            }

            return result;
        }
    }
}
