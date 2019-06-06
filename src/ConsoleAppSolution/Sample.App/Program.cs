using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Sample.App.Services;
using Sample.Lib.Services;
using System.Threading.Tasks;

namespace Sample.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // 設定は記述した順に上書きされる
            // 環境変数やコマンドラインで上書きする場合はjsonと同じパスで設定する

            // 例）環境変数で上書き
            // set Sample.B:App:Key1=...

            // 例）コマンドライン引数で上書き
            // dotnet Sample.B.App.dll --Sample.B:App:Key1=...

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<App.AppSettings>(config.GetSection("Sample.App"))
                .Configure<Lib.AppSettings>(config.GetSection("Sample.Lib"))
                .AddLogging(_ =>
                {
                    _.SetMinimumLevel(LogLevel.Debug);
                    _.AddNLog();
                })
                .AddSingleton<FooService>()
                .AddSingleton<BarService>()
                .AddSingleton<BazService>()
                .AddSingleton<Application>()
                .BuildServiceProvider();

            var application = serviceProvider.GetService<Application>();
            await application.RunAsync();
        }
    }
}
