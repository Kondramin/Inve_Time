using Inve_Time.Commands.Base;
using System.Windows;

namespace Inve_Time.Commands
{
    class CloseAppCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
