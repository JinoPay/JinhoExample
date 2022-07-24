using System;
using System.Collections.Concurrent;
using System.IO;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace N05_SeriLog_Wpf_Module.Utils
{
    public class SeriLogEventSink : ISeriLogEventSink
    {
        private readonly ITextFormatter _textFormatter =
            new MessageTemplateTextFormatter("{Timestamp} [{Level}] {Message}{Exception}");

        private ConcurrentQueue<string> LogQueue { get; } = new ConcurrentQueue<string>();

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            var renderSpace = new StringWriter();
            _textFormatter.Format(logEvent, renderSpace);
            LogQueue.Enqueue(renderSpace.ToString());
        }

        public ConcurrentQueue<string> GetLogQueue()
        {
            return LogQueue;
        }
    }
}