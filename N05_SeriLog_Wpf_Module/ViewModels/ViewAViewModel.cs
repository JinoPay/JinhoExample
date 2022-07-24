using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace N05_SeriLog_Wpf_Module.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private DelegateCommand _testCommand;
        public DelegateCommand TestCommand =>
            _testCommand ?? (_testCommand = new DelegateCommand(ExecuteTestCommand));

        void ExecuteTestCommand()
        {
            Log.Information("kk");
        }
        public ViewAViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
