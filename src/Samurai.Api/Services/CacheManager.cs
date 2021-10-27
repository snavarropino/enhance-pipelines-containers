using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Samurai.Api.Services
{
    public class CacheManager: ICacheManager
    {
        const string SecretName = "CacheConnection";
        private static string _connectionString;


        public CacheManager(IConfiguration configuration)
        {
            _connectionString = configuration[SecretName];
        }

        private readonly Lazy<ConnectionMultiplexer> _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_connectionString));

        public async Task<string> GetAsync(string key)
        {
            IDatabase cache = _connection.Value.GetDatabase();
            var result =  await cache.StringGetAsync(key);

            if (result.HasValue)
            {
                return result.ToString();
            }

            return null;
        }

        public async Task SetAsync(string key, string value)
        {
            IDatabase cache = _connection.Value.GetDatabase();
            await cache.StringSetAsync(key, value);
        }
    }
}