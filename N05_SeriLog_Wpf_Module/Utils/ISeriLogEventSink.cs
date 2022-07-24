using System.Collections.Concurrent;
using Serilog.Core;

namespace N05_SeriLog_Wpf_Module.Utils
{
    public interface ISeriLogEventSink : ILogEventSink
    {
        ConcurrentQueue<string> GetLogQueue();
    }
}