using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark.RedisBase
{
    public static class RedisValueExtensions
    {
        public static byte[] Parse(this RedisValue value, byte[] defaultValue)
        {
            byte[] result = defaultValue;
            if (value.HasValue)
                try
                {
                    result = value;
                }
                catch { }
            return result;
        }

        public static string Parse(this RedisValue value, string defaultValue)
        {
            string result = defaultValue;
            if (value.HasValue)
                try
                {
                    result = value;
                }
                catch { }
            return result;
        }

        public static double Parse(this RedisValue value, double defaultValue)
        {
            double result = defaultValue;
            if (value.HasValue)
                try
                {
                    result = (double)value;
                }
                catch { }
            return result;
        }

        public static long Parse(this RedisValue value, long defaultValue)
        {
            long result = defaultValue;
            if (value.HasValue)
                try
                {
                    result = (long)value;
                }
                catch { }
            return result;
        }

        public static int Parse(this RedisValue value, int defaultValue)
        {
            int result = defaultValue;
            if (value.HasValue)
                try
                {
                    result = (int)value;
                }
                catch { }
            return result;
        }

        public static bool Parse(this RedisValue value, bool defaultValue)
        {
            bool result = defaultValue;
            if (value.HasValue)
                try
                {
                    result = (bool)value;
                }
                catch { }
            return result;
        }
    }
}
