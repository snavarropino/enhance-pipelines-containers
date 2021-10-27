using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Samurai.Api.Extensions;
using Xunit;

namespace Samurai.Api.IntegrationTests
{
    public class SamuraiApiShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public SamuraiApiShould(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Samurais()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Samurais");

            // Assert
            var samurais = await response.GetToAsync<IEnumerable<Models.Samurai>>();
            Assert.True(samurais.First().Name.Equals("Takeshi"));
        }
    }
}