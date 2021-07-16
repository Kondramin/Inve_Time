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


        #region ViewModel MainWindow CurrentModel

        private ViewModel _CurrentModel;
        /// <summary>MainWindow CurrentModel</summary>
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            set => Set(ref _CurrentModel, value);
        }

        #endregion



        #region Commands

        #region Command ReAutorisationInAppCommand - ReAutisated in application

        /// <summary>ReAutisated in application</summary>
        private ICommand _ReAutorisationInAppCommand;

        /// <summary>ReAutisated in application</summary>
        public ICommand ReAutorisationInAppCommand => _ReAutorisationInAppCommand
            ??= new LambdaCommand(OnReAutorisationInAppCommandExequted, CanReAutorisationInAppCommandExequt);

        /// <summary>Checking the possibility of execution - ReAutisated in application</summary>
        /// <param name="p"></param>
        public bool CanReAutorisationInAppCommandExequt(object p) => true;

        /// <summary>Execution logic - ReAutisated in application</summary>
        /// <param name="p"></param>
        public void OnReAutorisationInAppCommandExequted(object p)
        {   
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();
        }


        #endregion

        #region Command ShowStartViewCommand - Show StartView

        /// <summary>Show StartView</summary>
        private ICommand _ShowStartViewCommand;

        /// <summary>Show StartView</summary>
        public ICommand ShowStartViewCommand => _ShowStartViewCommand
            ??= new LambdaCommand(OnShowStartViewCommandExequted, CanShowStartViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show StartView</summary>
        /// <param name="p"></param>
        public bool CanShowStartViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show StartView</summary>
        /// <param name="p"></param>
        public void OnShowStartViewCommandExequted(object p)
        {
            CurrentModel = new StartViewModel();
        }


        #endregion

        #endregion




        public MainWindowViewModel()
        {
            
        }
    }
}
