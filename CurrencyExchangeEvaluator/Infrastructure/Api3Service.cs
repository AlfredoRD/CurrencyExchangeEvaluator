using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeEvaluator.Infrastructure
{
    public class Api3Service : IExchangeRateService
    {
        public Task<ExchangeResult?> GetExchangeResultAsync(ExchangeRequest request)
        {
            decimal total = 58300.60m;
            return Task.FromResult<ExchangeResult?>(new ExchangeResult
            {
                ApiName = "API3",
                ConvertedAmount = total
            });
        }
    }
}
