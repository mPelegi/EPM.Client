using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.Helpers
{
    public class SizeConverter
    {
        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string ToConvert(Int64 value)
        {
            if (value < 0)
            {
                return "-" + ToConvert(-value);
            }

            if (value == 0)
            {
                return "0.0 bytes";
            }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        public static string ToConvert(UInt64 value)
        {
            if (value == 0)
            {
                return "0.0 bytes";
            }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        public static double ByteToGigabyte(UInt64 value)
        {
            if (value == 0)
            {
                return 0d;
            }

            return Math.Round((value / 1073741824d), 1);
        }

        public static double KilobyteToGigabyte(UInt64 value)
        {
            if (value == 0)
            {
                return 0d;
            }

            return Math.Round((value / 1048576d), 1);
        }
    }
}
