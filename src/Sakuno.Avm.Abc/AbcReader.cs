using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Sakuno.Avm.Abc
{
    internal ref struct AbcReader
    {
        private ReadOnlySpan<byte> _buffer;

        public int Length { get; }
        public int Position { get; set; }
        public ReadOnlySpan<byte> Remaining => _buffer[Position..];

        public AbcReader(ReadOnlySpan<byte> buffer)
        {
            _buffer = buffer;

            Length = _buffer.Length;
            Position = 0;
        }

        public byte ReadU8()
        {
            var result = Remaining[0];

            Position++;
            return result;
        }

        public T ReadU8<T>() where T : struct
        {
            var result = ReadU8();

            return Unsafe.As<byte, T>(ref result);
        }

        public uint ReadU32()
        {
            var result = 0u;

            for (var i = 0; i < 5; i++)
            {
                var current = ReadU8();

                result |= (current & 0x7Fu) << (i * 7);

                if ((current & 0x80) is 0)
                    break;
            }

            return result;
        }
        public int ReadU30() => (int)ReadU32() & int.MaxValue;
        public int ReadS32() => (int)ReadU32();

        public double ReadD64()
        {
            var result = BinaryPrimitives.ReadDoubleLittleEndian(Remaining);

            Position += sizeof(double);
            return result;
        }

        public int ReadS24()
        {
            var result = 0;

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<int, byte>(ref Unsafe.AsRef(result)), ref MemoryMarshal.GetReference(Remaining), 3);

            if (!BitConverter.IsLittleEndian)
                result = BinaryPrimitives.ReverseEndianness(result);

            result = (result << 8) >> 8;

            Position += 3;
            return result;
        }

        public string ReadString()
        {
            var length = ReadU30();
            var result = Encoding.UTF8.GetString(Remaining[..length]);

            Position += length;
            return result;
        }
    }
}
