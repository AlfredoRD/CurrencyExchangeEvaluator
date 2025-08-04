using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeEvaluator.Domain
{
    public class ExchangeResult
    {
        public string ApiName { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
