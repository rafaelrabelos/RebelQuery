using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery.Data
{
    using Mocks;

    public class TypeData : MocksData
    {
            /// <summary>
            /// 8 bits -128 to 127
            /// </summary>
            public sbyte TypeSbyte { get; set; }
            /// <summary>
            /// 8 bits 0 to 255
            /// </summary>
            public byte TypeByte { get; set; }
            /// <summary>
            /// 16 bits -32768 to 32767
            /// </summary>
            public short TypeShort { get; set; }
            /// <summary>
            /// 16 bits 0 to 65535
            /// </summary>
            public ushort TypeUshort { get; set; }
            /// <summary>
            /// 32 bits -2147483648 to 2147483647
            /// </summary>
            public int TypeInt { get; set; }
            /// <summary>
            /// 32 bits 0 to 4294967295
            /// </summary>
            public uint TypeUint { get; set; }
            /// <summary>
            /// 64 bits -9223372036854775808 to 9223372036854775807
            /// </summary>
            public long TypeLong { get; set; }

            /// <summary>
            /// 64 bits 0 to 18446744073709551615
            /// </summary>
            public ulong TypeUlong { get; set; }

            /// <summary>
            /// 32 bits 7 digits precision 1.5 x 10^-45 to 3.4 x 10^38
            /// </summary>
            public float TypeFloat { get; set; }
            /// <summary>
            /// 64 bits 15-16 digits precision 5.0 x 10^-324 to 1.7 x 10^308
            /// </summary>
            public double TypeDouble { get; set; }
            /// <summary>
            /// 128 bits 28-29 digits precision 1.0 x 10^-28 to 7.9 x 10^28
            /// </summary>
            public decimal TypeDecimal { get; set; }

            public char TypeChar { get; set; }
            public string TypeString { get; set; }
            public DateTime TypeDateTime { get; set; }
            public DateTimeOffset TypeDateTimeOffset { get; set; }

    }


}