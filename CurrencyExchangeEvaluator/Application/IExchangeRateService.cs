using CurrencyExchangeEvaluator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeEvaluator.Application
{
    public interface IExchangeRateService
    {
        Task<ExchangeResult?> GetExchangeResultAsync(ExchangeRequest request);
    }
}
