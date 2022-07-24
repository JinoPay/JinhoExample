using N05_SeriLog_Wpf_Module.Utils;
using N05_SeriLog_Wpf_Module.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Serilog;
using Serilog.Core;

namespace N05_SeriLog_Wpf_Module
{
    public class N05_SeriLog_Wpf_ModuleModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly ISeriLogEventSink _logEventSink;

        public N05_SeriLog_Wpf_ModuleModule(IRegionManager regionManager, ISeriLogEventSink logEventSink)
        {
            _regionManager = regionManager;
            _logEventSink = logEventSink;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Sink(logEventSink)
                .CreateLogger();
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}