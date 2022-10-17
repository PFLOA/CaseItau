using Serilog.Events;

namespace A4S.CaseItau.Logging.Loggers
{
    public class ConsoleLoggerConfiguracao
    {
        public bool Enabled { get; set; }
        public LogEventLevel MinimumLevel { get; set; }
    }
}
