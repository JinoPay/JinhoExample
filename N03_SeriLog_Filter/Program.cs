using System;
using Serilog;

namespace N03_SeriLog_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("all.txt")
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.MessageTemplate.Text.Contains("[test]"))
                    .WriteTo.File("test.txt"))
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.MessageTemplate.Text.Contains("[prac]"))
                    .WriteTo.File("prac.txt"))
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
