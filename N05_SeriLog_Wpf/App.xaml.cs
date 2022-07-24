using N05_SeriLog_Wpf.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using N05_SeriLog_Wpf_Module;
using N05_SeriLog_Wpf_Module.Utils;
using Serilog;
using Serilog.Core;

namespace N05_SeriLog_Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ISeriLogEventSink, SeriLogEventSink>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<N05_SeriLog_Wpf_ModuleModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
