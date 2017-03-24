using System;
using System.Collections.Generic;
using System.Text;
using Mark.RedisBase;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KeyGeneratorTest
    {
        [TestMethod]
        public async Task NewTest()
        {
            var db = await Settings.GetDatabaseAsync("Development");
            var keyGenerator = new KeyGenerator(db);
            var key1 = keyGenerator.New();
            var key2 = keyGenerator.New();
            var key3 = keyGenerator.New();

            Assert.IsTrue(key1 < key2 && key2 < key3);
        }
    }
}
