using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Samurai.Api.Infrastructure;

namespace Samurai.Api.Services
{
    public class SamuraiService : ISamuraiService
    {
        private readonly ICacheManager _cacheManager;
        private readonly SamuraiContext _context;

        public SamuraiService(ICacheManager cacheManager, SamuraiContext context)
        {
            _cacheManager = cacheManager;
            _context = context;
        }
        
        public async Task<IEnumerable<Models.Samurai>> GetAllAsync()
        {
            var samuraisInCache = await _cacheManager.GetAsync("Samurais");

            if (samuraisInCache is null)
            {
                var samurais = await _context
                                                .Samurais
                                                .Include(s=>s.Quotes)
                                                .Include(s=> s.Battles)
                                                .ToListAsync();

                await _cacheManager.SetAsync("Samurais", JsonSerializer.Serialize(samurais));
                return samurais;
            }

            return JsonSerializer.Deserialize<IEnumerable<Models.Samurai>>(samuraisInCache);
        }
    }
}
