using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExample.Entities;

namespace WebApplicationExample.Controllers
{
    [ApiController]
    [Route("api/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ContractDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ContractDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> Send(Contract request)
        {
            request.CorrelationId = Guid.NewGuid();

            _context.Add(request);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
