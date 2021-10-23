using System.Threading.Tasks;

namespace Samurai.Api.Services
{
    public interface ICacheManager
    {
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
    }
}