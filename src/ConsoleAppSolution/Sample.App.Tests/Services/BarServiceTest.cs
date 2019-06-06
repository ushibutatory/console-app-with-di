using Microsoft.Extensions.DependencyInjection;
using Sample.App.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Sample.App.Tests.Services
{
    public class BarServiceTest
    {
        private readonly IServiceProvider _provider;

        public BarServiceTest(ITestOutputHelper outputHelper)
        {
            _provider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<BarService>()
                .BuildServiceProvider();
        }

        [Fact]
        public async Task RegisterAsync()
        {
            // 出力先をDIして結果を検証するのがよさそう
            var service = _provider.GetService<BarService>();
            await service.RegisterAsync("Test");
        }
    }
}
