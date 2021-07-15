using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.ViewModels.Base;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace Inve_Time.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public static Employee MainWindowEmployee;




        #region string MainWindow Title  = "Inve_Time"

        private string _Title = "Inve_Time";
        /// <summary>MainWindow Title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion


        #region string MainWindow StatusBarEmployeeName

        private string _StatusBarEmployeeName = MainWindowEmployee.Name;
        
        /// <summary>MainWindow StatusBarEmployeeName</summary>
        public string StatusBarEmployeeName
        {
            get => _StatusBarEmployeeName;
            set => Set(ref _StatusBarEmployeeName, value);
        }

        #endregion


        #region string MainWindow StatusBarEmployeePositionName

        private string _StatusBarEmployeePositionName = MainWindowEmployee.Position.Name;

        /// <summary>MainWindow StatusBarEmployeePositionName</summary>
        public string StatusBarEmployeePositionName
        {
            get => _StatusBarEmployeePositionName;
            set => Set(ref _StatusBarEmployeePositionName, value);
        }

        #endregion




        #region Commands

        #region ReAutorisationInAppCommand

        public ICommand ReAutorisationInAppCommand { get; }

        public void OnReAutorisationCommandExequted(object p)
        {   
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();
        }


        #endregion

        #endregion




        public MainWindowViewModel()
        {
            ReAutorisationInAppCommand = new LambdaCommand(OnReAutorisationCommandExequted);
        }
    }
}
