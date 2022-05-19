using System;
using Serilog;

namespace N02_SerilLog_File
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            while (true)
            {
                var input = Console.ReadLine();

                if (string.Equals(input, "exit", StringComparison.CurrentCultureIgnoreCase)) break;
                Log.Information(input);
            }
        }
    }
}
