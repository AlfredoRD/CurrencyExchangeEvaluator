using CurrencyExchangeEvaluator.Application;
using CurrencyExchangeEvaluator.Domain;
using CurrencyExchangeEvaluator.Infrastructure;


var request = new ExchangeRequest
{
    SourceCurrency = "USD",
    TargetCurrency = "DOP",
    Amount = 1000
};

var services = new List<IExchangeRateService>
{
    new Api1Service(),
    new Api2Service(),
    new Api3Service()
};

var comparer = new ExchangeRateComparer(services);
var best = await comparer.GetBestOfferAsync(request);

if (best != null)
{
    Console.WriteLine($"Mejor oferta: {best.ApiName}, Monto: {best.ConvertedAmount}");
}
else
{
    Console.WriteLine("No se pudo obtener ninguna conversión.");
}
