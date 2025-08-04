using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;

public class ExchangeRateComparerTests
{
    [Fact]
    public async Task GetBestOfferAsync_ReturnsHighestAmount()
    {
        var services = new List<IExchangeRateService>
        {
            new FakeApi("API1", 1000),
            new FakeApi("API2", 1200),
            new FakeApi("API3", 1100)
        };

        var comparer = new ExchangeRateComparer(services);
        var result = await comparer.GetBestOfferAsync(new ExchangeRequest());

        Assert.NotNull(result);
        Assert.Equal("API2", result!.ApiName);
        Assert.Equal(1200, result.ConvertedAmount);
    }

    [Fact]
    public async Task GetBestOfferAsync_IgnoresNullResponses()
    {
        var services = new List<IExchangeRateService>
        {
            new FakeApi("API1", 1000),
            new FakeApi(null, null), 
            new FakeApi("API3", 800)
        };

        var comparer = new ExchangeRateComparer(services);
        var result = await comparer.GetBestOfferAsync(new ExchangeRequest());

        Assert.NotNull(result);
        Assert.Equal("API1", result!.ApiName);
    }

    [Fact]
    public async Task GetBestOfferAsync_ReturnsNullIfAllFail()
    {
        var services = new List<IExchangeRateService>
        {
            new FakeApi(null, null),
            new FakeApi(null, null)
        };

        var comparer = new ExchangeRateComparer(services);
        var result = await comparer.GetBestOfferAsync(new ExchangeRequest());

        Assert.Null(result);
    }
}

public class FakeApi : IExchangeRateService
{
    private readonly string? _name;
    private readonly decimal? _amount;

    public FakeApi(string? name, decimal? amount)
    {
        _name = name;
        _amount = amount;
    }

    public Task<ExchangeResult?> GetExchangeResultAsync(ExchangeRequest request)
    {
        if (_name == null || _amount == null)
            return Task.FromResult<ExchangeResult?>(null);

        return Task.FromResult<ExchangeResult?>(new ExchangeResult
        {
            ApiName = _name,
            ConvertedAmount = _amount.Value
        });
    }
}
