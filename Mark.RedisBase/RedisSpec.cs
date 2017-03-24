using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark.RedisBase
{
    public abstract class RedisSpec
    {
        public string AppCode { get; private set; }

        public string ModuleCode { get; private set; }

        public string Path { get; private set; }

        public RedisSpec(string appCode, string moduleCode, string path)
        {
            if (string.IsNullOrWhiteSpace(appCode))
                throw new ArgumentNullException("appCode");

            if (string.IsNullOrWhiteSpace(moduleCode))
                throw new ArgumentNullException("moduleCode");

            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("path");

            AppCode = appCode;
            ModuleCode = moduleCode;
            Path = path;
        }

        public override string ToString()
        {
            return $"{AppCode}:{ModuleCode}:{Path}";
        }

        public static implicit operator StackExchange.Redis.RedisKey(RedisSpec key)
        {
            return key.ToString();
        }
    }
}
