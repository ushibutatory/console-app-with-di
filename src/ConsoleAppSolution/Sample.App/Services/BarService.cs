using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Sample.App.Services
{
    public class BarService
    {
        private readonly ILogger<BarService> _logger;

        public BarService(ILogger<BarService> logger)
        {
            _logger = logger;
        }

        public async Task RegisterAsync(string value)
        {
            // どこかに保存する
            _logger.LogDebug($"{nameof(value)}: {value}");

            await Task.CompletedTask;
        }
    }
}
