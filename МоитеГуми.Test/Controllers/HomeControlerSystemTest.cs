namespace МоитеГуми.Test.Controllers
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using System.Threading.Tasks;
    using Xunit;

    public class HomeControlerSystemTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public HomeControlerSystemTest(WebApplicationFactory<Startup> factory)
              => this.factory = factory;


        [Fact]
        public async Task IndexShouldreturnCorrectStatusCode()
        {
            var client = this.factory.CreateClient();

            var result = await client.GetAsync("/");


            Assert.True(result.IsSuccessStatusCode);
        }
    }
}
