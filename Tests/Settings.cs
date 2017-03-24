using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Settings
    {
        private const string DevelopmentConnectionString = "push_role,password=2aH5Y6tc4SqEXdTEUQeN";
        private const string ProductionConnectionString = "push_role";

        private static ConnectionMultiplexer _multiplexer;

        public static async Task<IDatabase> GetDatabaseAsync(string env)
        {
            if (_multiplexer == null)
            {
                var connectionString = string.Equals("development", env, StringComparison.OrdinalIgnoreCase) ?
                    DevelopmentConnectionString : ProductionConnectionString;

                _multiplexer = await ConnectionMultiplexer.ConnectAsync(connectionString);
            }
            return _multiplexer.GetDatabase();
        }
    }
}
