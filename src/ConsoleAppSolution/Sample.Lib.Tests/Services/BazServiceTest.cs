using Microsoft.Extensions.DependencyInjection;
using Sample.Lib.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Sample.Lib.Tests.Services
{
    public class BazServiceTest
    {
        private readonly IServiceProvider _provider;

        public BazServiceTest(ITestOutputHelper outputHelper)
        {
            _provider = new ServiceCollection()
                .Configure<AppSettings>(_ =>
                {
                    _.Key = "*";
                })
                .AddLogging()
                .AddSingleton<BazService>()
                .BuildServiceProvider();
        }

        [Fact]
        public async Task FixAsync()
        {
            var service = _provider.GetService<BazService>();
            var result = await service.FixAsync("input");

            Assert.Equal("*input*", result);
        }
    }
}
