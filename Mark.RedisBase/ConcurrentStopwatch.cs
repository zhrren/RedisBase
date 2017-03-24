using System;
using System.Diagnostics;

namespace Mark.RedisBase
{
    public static class ConcurrentStopwatch
    {
        private static readonly DateTime _utcEpoch = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly Stopwatch _sw = Stopwatch.StartNew();

        private static readonly object _lastTicksLock = new object();
        private static long _lastTicks;
        private static readonly long _timeZeroTicks;

        private static readonly object _lastMillisecondsLock = new object();
        private static long _lastMilliseconds;
        private static readonly long _timeZeroMilliseconds;

        static ConcurrentStopwatch()
        {
            var lastInitialized = DateTime.UtcNow;
            var timeZero = lastInitialized.Subtract(_utcEpoch);

            _timeZeroTicks = timeZero.Ticks/10;
            _timeZeroMilliseconds = (long)timeZero.TotalSeconds;
        }

        public static long GetTicks()
        {
            lock (_lastTicksLock)
            {
                long value = 0;
                while (value <= _lastTicks)
                {
                    value = _timeZeroTicks + (_sw.Elapsed.Ticks/10);
                }
                _lastTicks = value;
                return value;
            }
        }

        public static long GetMilliseconds()
        {
            lock (_lastMillisecondsLock)
            {
                long value = 0;
                while (value <= _lastMilliseconds)
                {
                    value = _timeZeroMilliseconds + (long)_sw.Elapsed.TotalMilliseconds;
                }
                _lastMilliseconds = value;
                return value;
            }
        }
    }
}