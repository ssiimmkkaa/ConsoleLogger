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

        /// <summary>
        /// for static classes
        /// </summary>
        /// <param name="type">type of static class</param>
        public ConsoleLogger(Type type)
        {
            _type = type;
        }

        private void Log(string message, LogType type, bool inFile = true)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = type.Color();
            string str1 = $"{DateTime.Now} [thread: {Thread.CurrentThread.ManagedThreadId}] [{type.ToShortString()}]";
            Console.Write(str1);
            Console.ForegroundColor = oldColor;
            string str2 = $": [{_type}] {message}";
            Console.WriteLine(str2);
            if (inFile)
            {
                FileLogger.Log($"{str1}{str2}");
            }
        }

        public void LogOther(string message, bool inFile = true) => Log(message, LogType.Other, inFile);

        public void LogError(string message, bool inFile = true) => Log(message, LogType.Error, inFile);

        public void LogWarning(string message, bool inFile = true) => Log(message, LogType.Warning, inFile);

        public void LogInfo(string message, bool inFile = true) => Log(message, LogType.Information, inFile);
    }
}