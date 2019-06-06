using Microsoft.Extensions.Logging;
using Sample.App.Services;
using Sample.Lib.Services;
using System.Threading.Tasks;

namespace Sample.App
{
    public class Application
    {
        private readonly ILogger<Application> _logger;

        private readonly FooService _fooService;
        private readonly BarService _barService;
        private readonly BazService _bazService;

        public Application(ILogger<Application> logger
            , FooService fooService
            , BarService barService
            , BazService bazService)
        {
            _logger = logger;

            _fooService = fooService;
            _barService = barService;
            _bazService = bazService;
        }

        public async Task RunAsync()
        {
            _logger.LogDebug("Application Start.");

            // 何かの値を取得する
            var value = await _fooService.GetValueAsync();

            // 何かしら加工する
            var result = await _bazService.FixAsync(value);

            // どこかに登録する
            await _barService.RegisterAsync(result);

            _logger.LogDebug("Application End.");
        }
    }
}
