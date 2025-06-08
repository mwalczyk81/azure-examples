using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http;

namespace Examples.ApiTests;

public class WebApiSmokeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WebApiSmokeTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Root_ReturnsHello()
    {
        using var client = _factory.CreateClient();
        var result = await client.GetStringAsync("/");
        Assert.Equal("Hello from Aspire Web API!", result);
    }
}
