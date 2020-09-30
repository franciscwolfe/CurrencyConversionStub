using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApi.Controllers
{
    [Route("[controller]")]
    [EnableCors]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private static readonly Dictionary<string, double> Currencies = new Dictionary<string, double>
        {
            { "GBP", 1 },
            { "USD", 0.78 },
            { "AUD", 0.56 },
            { "EUR", 0.91 },
        };


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Currencies.Keys;
        }

        [HttpGet]
        [Route("convert")]
        public Decimal ConvertValue(string inputCurrency, string outputCurrency, double value)
        {
            return decimal.Round(Convert.ToDecimal(value * Currencies[inputCurrency] / Currencies[outputCurrency]), 2);
        }
    }
}
