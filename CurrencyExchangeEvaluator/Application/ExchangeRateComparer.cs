using CurrencyExchangeEvaluator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeEvaluator.Application
{
    public class ExchangeRateComparer
    {
        private readonly List<IExchangeRateService> _services;

        public ExchangeRateComparer(IEnumerable<IExchangeRateService> services)
        {
            _services = services.ToList();
        }

        public async Task<ExchangeResult?> GetBestOfferAsync(ExchangeRequest request)
        {
            var tasks = _services.Select(s => s.GetExchangeResultAsync(request));
            var results = await Task.WhenAll(tasks);

            return results
                .Where(r => r != null)
                .OrderByDescending(r => r!.ConvertedAmount)
                .FirstOrDefault();
        }
    }
}
