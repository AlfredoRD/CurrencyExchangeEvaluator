using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;
using CurrencyExchangeEvaluator.Tests;

namespace ExchangeRateComparerTests
{
    public class GetBestOffer_ReturnsHighestAmount
    {
        [Fact]
        public async Task Returns_Highest_Offer()
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
    }
}
