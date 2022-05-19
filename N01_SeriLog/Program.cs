using System;
using Serilog;

namespace N01_SeriLog
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
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
