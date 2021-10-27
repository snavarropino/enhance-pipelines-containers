using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Samurai.Api.Models;

namespace Samurai.Api.Services
{
    public class SamuraiService : ISamuraiService
    {
        private readonly ICacheManager _cacheManager;
        private readonly ILogger<SamuraiService> _logger;
        private const string CacheKey = "Samurais";

        public SamuraiService(ICacheManager cacheManager,ILogger<SamuraiService> logger)
        {
            _cacheManager = cacheManager;
            _logger = logger;
        }
        
        public async Task<IEnumerable<Models.Samurai>> GetAllAsync()
        {
            var samuraisInCache = await _cacheManager.GetAsync(CacheKey);

            if (samuraisInCache != null)
            {
                _logger.LogInformation("Cache hint!");
                return JsonSerializer.Deserialize<IEnumerable<Models.Samurai>>(samuraisInCache);
            }

            _logger.LogInformation("Reading from database");
            var samurais= await GetSamuraisFromDatabaseAsync();
            await _cacheManager.SetAsync(CacheKey, JsonSerializer.Serialize(samurais));
            return samurais;
        }

        private async Task<IEnumerable<Models.Samurai>> GetSamuraisFromDatabaseAsync()
        {
            await Task.Delay(3000);
            var samurais = GetDefaultSamurais();

           
            return samurais;
        }

        private static IEnumerable<Models.Samurai> GetDefaultSamurais()
        {
            return new List<Models.Samurai>()
            {
                new()
                {
                    Name    = "Takeshi",
                    Battles = new List<Battle>()
                    {
                        new()
                        {
                            Name = "Tokio defense",
                            Location = "Tokio",
                            Date = new DateTime(1810,1,1)
                        }
                    },
                    Quotes = new List<Quote>()
                    {
                        new()
                        {
                            Text = "Train as much as you can"
                        }
                    }
                },
                new()
                {
                    Name    = "Koji",
                    Battles = new List<Battle>()
                    {
                        new()
                        {
                            Name = "Tokio defense",
                            Location = "Tokio",
                            Date = new DateTime(1810,1,1)
                        }
                    },
                    Quotes = new List<Quote>()
                    {
                        new()
                        {
                            Text = "Cofee time!"
                        }
                    }
                }
            };
        }
    }
}
