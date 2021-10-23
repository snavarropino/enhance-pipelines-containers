using System.Collections.Generic;
using System.Threading.Tasks;

namespace Samurai.Api.Services
{
    public interface ISamuraiService
    {
        Task<IEnumerable<Models.Samurai>> GetAllAsync();
    }
}