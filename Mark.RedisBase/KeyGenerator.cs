using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark.RedisBase
{
    public class KeyGenerator
    {
        private IDatabase _db;
        private RedisKey _keySpec = "KeyGenerator";
        private readonly string _keyField = "key";
        private readonly Random _random = new Random();

        public KeyGenerator(IDatabase db)
        {
            _db = db;
        }

        public long New()
        {
            if (!_db.KeyExists(_keySpec))
            {
                var init = ConcurrentStopwatch.GetMilliseconds();
                _db.HashSet(_keySpec, _keyField, init);
            }

            var random = _random.Next(1, 100);
            var key = _db.HashIncrement(_keySpec, _keyField, random);
            return key;
        }
    }
}
