using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using A4S.CaseItau.Logging;

namespace A4S.CaseItau.Api
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://*:80");
                    webBuilder.UseStartup<Startup>();
                }).ConfigurarSerilog();
    }
}
