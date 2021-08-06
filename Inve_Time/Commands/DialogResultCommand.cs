using System;
using System.Windows.Input;

namespace Inve_Time.Commands
{
    /// <summary>Command, what using to finish dialog with user</summary>
    class DialogResultCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool? DialogResult { get; set; }

        public bool CanExecute(object parameter) => App.CurrentWindow != null;

        public void Execute(object parameter)
        {

            if (!CanExecute(parameter)) return;


            var dialog_result = DialogResult;
            if (parameter != null)
                dialog_result = (bool?)(Convert.ChangeType(parameter, typeof(bool?)));


            var window = App.CurrentWindow;

            window.DialogResult = dialog_result;
            window.Close();
        }
    }
}
