using StackExchange.Redis;
using System.Linq;
using System.Net;

namespace RedisPublisher
{
    internal abstract class RedisConnect
    {
        public IDatabase Redis { get; set; }

        internal RedisConnect()
        {
            Redis = RedisServer.Redis;
        }

        public abstract void PromptInputConsole();

        public abstract void WalkthroughFunctionalities();
    }
}