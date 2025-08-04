using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;


namespace CurrencyExchangeEvaluator.Infrastructure
{
    public class Api2Service : IExchangeRateService
    {
        public Task<ExchangeResult?> GetExchangeResultAsync(ExchangeRequest request)
        {
            try
            {
                decimal result = 58000.75m;
                var exchangeResult = new ExchangeResult
                {
                    ApiName = "API2",
                    ConvertedAmount = result
                };

                return Task.FromResult<ExchangeResult?>(exchangeResult);
            }
            catch
            {
                return Task.FromResult<ExchangeResult?>(null);
            }
        }
    }
}
