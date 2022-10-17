using System.Collections.Generic;
using Serilog.Events;
using System.Text;
using System;

namespace A4S.CaseItau.Logging.Loggers
{
    public class GrayLogLoggerConfiguracao
    {
        public bool Enabled { get; set; } = false;  
        public string Host { get; set; } = "localhost";
        public int Port { get; set; }
        public LogEventLevel MinimumLevel { get; set; }
    }
}
