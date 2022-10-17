using Serilog.Sinks.Graylog.Core.Transport;
using A4S.CaseItau.Logging.Loggers;
using Serilog.Sinks.Graylog;
using Serilog;

namespace A4S.CaseItau.Logging.Extension
{
    public static class LoggerConfigurationExtension
    {
        public static LoggerConfiguration AddConsoleLogger(this LoggerConfiguration loggerConfiguration, ConsoleLoggerConfiguracao consoleLoggerConfiguracao) => 
            consoleLoggerConfiguracao.Enabled ? loggerConfiguration.WriteTo.Console(consoleLoggerConfiguracao.MinimumLevel) : loggerConfiguration;
        public static LoggerConfiguration AddGrayLogger(this LoggerConfiguration loggerConfiguration, GrayLogLoggerConfiguracao grayLoggerConfiguracao) => 
            grayLoggerConfiguracao.Enabled ? loggerConfiguration.WriteTo.Graylog(grayLoggerConfiguracao.Host, grayLoggerConfiguracao.Port, TransportType.Udp, grayLoggerConfiguracao.MinimumLevel) : loggerConfiguration;
    }
}
