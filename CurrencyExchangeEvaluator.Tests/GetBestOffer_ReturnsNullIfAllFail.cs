using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;
using CurrencyExchangeEvaluator.Tests;

namespace ExchangeRateComparerTests
{
    public class GetBestOffer_ReturnsNullIfAllFail
    {
        [Fact]
        public async Task Returns_Null_If_All_APIs_Fail()
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
}
