using Microsoft.Extensions.DependencyInjection;
using Sample.App.Services;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Sample.App.Tests.Services
{
    public class FooServiceTest
    {
        private readonly IServiceProvider _provider;

        public FooServiceTest(ITestOutputHelper outputHelper)
        {
            _provider = new ServiceCollection()
                .Configure<AppSettings>(_ =>
                {
                    _.Key = "Key";
                    _.Sub = new AppSettings.SubSettings
                    {
                        Key = "SubValue"
                    };
                })
                .AddLogging()
                .AddSingleton<FooService>()
                .BuildServiceProvider();
        }

        [Fact]
        public async Task GetValueAsync()
        {
            var service = _provider.GetService<FooService>();
            var value = await service.GetValueAsync();

            Assert.Equal("Key", value);
        }
    }
}
