using System;
using System.Threading;

namespace ConsoleLogger
{
    public class ConsoleLogger<T>
    {
        private readonly Type _type;

        public ConsoleLogger()
        {
            _type = typeof(T);
        }

        private void Log(string message, LogType type)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = type.Color();
            Console.Write($"{DateTime.Now} [thread: {Thread.CurrentThread.ManagedThreadId}] [{type.ToShortString()}]");
            Console.ForegroundColor = oldColor;
            Console.WriteLine($": [{_type}] {message}");
        }

        public void LogOther(string message) => Log(message, LogType.Other);

        public void LogError(string message) => Log(message, LogType.Error);

        public void LogWarning(string message) => Log(message, LogType.Warning);

        public void LogInfo(string message) => Log(message, LogType.Information);
    }
}