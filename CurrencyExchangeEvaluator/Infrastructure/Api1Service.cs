using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;


namespace CurrencyExchangeEvaluator.Infrastructure
{
    public class Api1Service : IExchangeRateService
    {
        public Task<ExchangeResult?> GetExchangeResultAsync(ExchangeRequest request)
        {
            try
            {
                decimal rate = 57.25m;
                var result = new ExchangeResult
                {
                    ApiName = "API1",
                    ConvertedAmount = request.Amount * rate
                };

                return Task.FromResult<ExchangeResult?>(result);
            }
            catch
            {
                return Task.FromResult<ExchangeResult?>(null);
            }
        }
    }
}
