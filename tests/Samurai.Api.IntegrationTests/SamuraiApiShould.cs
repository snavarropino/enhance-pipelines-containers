using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Samurai.Api.Infrastructure;
using Xunit;

namespace Samurai.Api.IntegrationTests
{
    public class SamuraiApiShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SamuraiApiShould(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            var context = _factory.Services.CreateScope().ServiceProvider.GetService<SamuraiContext>();
            DbInitializer.Initialize(context);
        }

        [Fact]
        public async Task Get_Samurais()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Samurais");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}