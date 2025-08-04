using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;


namespace CurrencyExchangeEvaluator.Tests
{
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
}
