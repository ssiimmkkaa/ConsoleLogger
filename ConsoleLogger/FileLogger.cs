using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ConsoleLogger
{
    public static class FileLogger
    {
        private static ConsoleLogger<object> _logger;
        private static LoggerConfig _loggerConfig;

        static FileLogger()
        {
            _loggerConfig = JsonSerializer.Deserialize<LoggerConfig>(File.ReadAllText("logger.config.json"));
            _logger = new ConsoleLogger<object>(typeof(FileStream));
        }

        public static void Log(string message)
        {
            try
            {
                string path = string.IsNullOrEmpty(_loggerConfig.Path) ? "" : $"{_loggerConfig.Path}\\";
                using (StreamWriter stream =
                    new StreamWriter($"{path}log_{DateTime.Now.ToString("dd_MM_yyyy")}.log", true, Encoding.Default))
                {
                    stream.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }
    }
}