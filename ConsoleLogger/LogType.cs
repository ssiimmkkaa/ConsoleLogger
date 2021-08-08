using System;

namespace ConsoleLogger
{
    public enum LogType
    {
        Other,
        Error,
        Warning,
        Information
    }

    public static class LogTypeConverter
    {
        public static string ToShortString(this LogType type) =>
            type switch
            {
                LogType.Other => "othr",
                LogType.Error => "err",
                LogType.Warning => "wrn",
                LogType.Information => "info",
                _ => "???"
            };


        public static ConsoleColor Color(this LogType type) =>
            type switch
            {
                LogType.Other => ConsoleColor.Blue,
                LogType.Error => ConsoleColor.Red,
                LogType.Warning => ConsoleColor.Yellow,
                LogType.Information => ConsoleColor.Green,
                _ => ConsoleColor.Magenta
            };
    }
}