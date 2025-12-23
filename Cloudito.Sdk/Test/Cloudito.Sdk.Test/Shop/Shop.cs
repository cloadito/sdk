using Cloudito.Sdk.Services;
using Newtonsoft.Json;

namespace Cloudito.Sdk.Test;

public class ShopTest(TestFixture fixture, ITestOutputHelper outputHelper) : IClassFixture<TestFixture>
{
    private readonly IShop _shop = fixture.ServiceProvider.GetRequiredService<IShop>();

    [Fact]
    public async Task GetByMetadata()
    {
        FindShopRequest request = new(null, new("Code", "asdasg2341sdg"));
        var shop = await _shop.FindAsync(request);

        outputHelper.WriteLine("Find shop request {0}", JsonConvert.SerializeObject(shop));
        Assert.True(shop.Success);
    }
}