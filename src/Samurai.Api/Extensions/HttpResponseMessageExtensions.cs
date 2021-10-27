using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Samurai.Api.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> GetToAsync<T>(this HttpResponseMessage responseMessage)
        {
            var json = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
