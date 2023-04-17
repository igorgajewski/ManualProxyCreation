using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ManualProxyCreation.Infrastructure.Logging
{
    public static class Logger
    {
        private static ILogger _logger;
        private static string _logConfigPath;

        public static void Initialize(string logConfigPath)
        {
            if (_logger == null)
            {
                if (string.IsNullOrWhiteSpace(logConfigPath))
                {
                    throw new ArgumentNullException(nameof(logConfigPath));
                }
                if (!File.Exists(logConfigPath))
                {
                    throw new ArgumentException("Log config file not found in provided directory.", nameof(logConfigPath));
                }

                var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }


                _logConfigPath = logConfigPath;
                _logger = LogManager.GetCurrentClassLogger();
                LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(_logConfigPath);
            }
        }
    }
}
