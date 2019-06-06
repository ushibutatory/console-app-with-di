using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Sample.Lib.Services
{
    public class BazService
    {
        private readonly ILogger<BazService> _logger;
        private readonly AppSettings _appSettings;

        public BazService(ILogger<BazService> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public async Task<string> FixAsync(string value)
        {
            _logger.LogDebug($"Sample.Lib:Key: {_appSettings.Key}");

            // 何かしらの処理
            await Task.Delay(0);

            // 何かしらの結果を返す
            return $"{_appSettings.Key}{value}{_appSettings.Key}";
        }
    }
}
