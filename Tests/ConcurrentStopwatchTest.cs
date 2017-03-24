using System;
using Mark.RedisBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ConcurrentStopwatchTest
    {
        [TestMethod]
        public void GetMicrosecondsTest()
        {
            var result1 = ConcurrentStopwatch.GetTicks();
            var result2 = ConcurrentStopwatch.GetMilliseconds();
            Assert.IsTrue(result1 > 0);
        }
    }
}
