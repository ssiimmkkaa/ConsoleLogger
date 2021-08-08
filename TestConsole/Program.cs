using ConsoleLogger;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main()
        {
            ConsoleLogger<Program> logger = new ConsoleLogger<Program>();

            logger.LogOther("This is other message");

            Thread.Sleep(1000);

            logger.LogError("This is error message");

            Thread.Sleep(1000);

            logger.LogWarning("This is warning message");

            Thread.Sleep(1000);

            logger.LogInfo("This is info message");
        }
    }
}