using Inve_Time.Commands.Base;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    class AutorisationWindowViewModel : ViewModel
    {
        private readonly IAutorisationService _AutorisationService;



        #region string AutorisationWindow Title  = "Авторизуйтесь в системе"

        private string _Title = "Авторизуйтесь в системе";
        /// <summary>AutorisationWindow Title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion


        #region string AutorisationWindow LoginTextBox

        private string _LoginTextBox;

        /// <summary>AutorisationWindow LoginTextBox</summary>
        public string LoginTextBox
        {
            get => _LoginTextBox;
            set => Set(ref _LoginTextBox, value);
        }

        #endregion



        #region Commands


        #region Command AutorisationCommand - Add new employee

        /// <summary>Add new employee</summary>
        private ICommand _AutorisationCommand;

        /// <summary>Add new employee</summary>
        public ICommand AutorisationCommand => _AutorisationCommand
            ??= new LambdaCommand(OnAutorisationCommandExequted, CanAutorisationCommandExequt);

        /// <summary>Checking the possibility of execution - Add new employee</summary>
        /// <param name="p"></param>
        public bool CanAutorisationCommandExequt(object p) => true;

        /// <summary>Execution logic - Add new employee</summary>
        /// <param name="p"></param>
        public void OnAutorisationCommandExequted(object p)
        {
            PasswordBox pwdBox = p as PasswordBox;

            if (_AutorisationService.ValidateLoginAndPassword(LoginTextBox, pwdBox.Password))
            {
                MainWindowViewModel.AutorisatedEmployee = _AutorisationService.AutorisatedUser;
                var mainWindow = new MainWindow();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = mainWindow;
            }
            else
            {
                LoginTextBox = "";
                pwdBox.Password = "";
            }
        }

        #endregion


        #endregion



        public AutorisationWindowViewModel(IAutorisationService autorisationService)
        {
            _AutorisationService = autorisationService;
        }
    }
}
