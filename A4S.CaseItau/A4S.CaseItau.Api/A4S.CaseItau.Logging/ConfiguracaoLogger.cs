using Microsoft.Extensions.Configuration;
using A4S.CaseItau.Logging.Extension;
using A4S.CaseItau.Logging.Loggers;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace A4S.CaseItau.Logging
{
    public static class ConfiguracaoLogger
    {
        public static IHostBuilder ConfigurarSerilog(this IHostBuilder hostBuilder) =>
            hostBuilder.UseSerilog((context, loggerConfiguration) => 
                ConfigureSerilogLogger(loggerConfiguration, context.Configuration));

        private static LoggerConfiguration ConfigureSerilogLogger(LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            GrayLogLoggerConfiguracao grayLogger = new GrayLogLoggerConfiguracao();
            configuration.GetSection("Logging:Graylog").Bind(grayLogger);

            ConsoleLoggerConfiguracao consoleLogger = new ConsoleLoggerConfiguracao();
            configuration.GetSection("Logging:Console").Bind(consoleLogger);

            return loggerConfiguration.AddGrayLogger(grayLogger).AddConsoleLogger(consoleLogger);
        }
    }
}
