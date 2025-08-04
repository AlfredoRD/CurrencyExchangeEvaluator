using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;
using CurrencyExchangeEvaluator.Tests;

namespace ExchangeRateComparerTests
{
    public class GetBestOffer_IgnoresNullResponses
    {
        [Fact]
        public async Task Ignores_Null_APIs()
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
    }
}
