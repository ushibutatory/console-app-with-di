using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Sample.App.Services
{
    public class FooService
    {
        private readonly ILogger<FooService> _logger;
        private readonly AppSettings _appSettings;

        public FooService(ILogger<FooService> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public async Task<string> GetValueAsync()
        {
            _logger.LogDebug($"Sample.App:Key: {_appSettings.Key}");
            _logger.LogDebug($"Sample.App:Sub:Key: {_appSettings.Sub.Key}");

            // 何か重い処理
            await Task.Delay(1000);

            // 何かの値を返す
            return _appSettings.Key;
        }
    }
}
