using Inve_Time.Commands.Base;
using Inve_Time.Interfaces.Services;
using Inve_Time.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inve_Time.ViewModels.WindowsViewModels
{
    internal class AutorisationWindowViewModel : ViewModel
    {
        private readonly IAutorisationService _AutorisationService;


        public AutorisationWindowViewModel(IAutorisationService autorisationService) => _AutorisationService = autorisationService;



        #region string Title  = "Авторизуйтесь в системе"

        private string _Title = "Авторизуйтесь в системе";
        /// <summary>AutorisationWindow Title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion



        #region string LoginTextBox

        private string _LoginTextBox;

        /// <summary>AutorisationWindow LoginTextBox</summary>
        public string LoginTextBox
        {
            get => _LoginTextBox;
            set => Set(ref _LoginTextBox, value);
        }

        #endregion



        #region Commands


        #region Command AutorisationCommand - Autorisation in app 

        /// <summary>Autorisation in app </summary>
        private ICommand _AutorisationCommand;

        /// <summary>Autorisation in app </summary>
        public ICommand AutorisationCommand => _AutorisationCommand
            ??= new LambdaCommand(OnAutorisationCommandExequted);

        /// <summary>Execution logic - Autorisation in app </summary>
        /// <param name="p">PasswordBox</param>
        public void OnAutorisationCommandExequted(object p)
        {
            PasswordBox pwdBox = p as PasswordBox;

            if (_AutorisationService.ValidateLoginAndPassword(LoginTextBox, pwdBox.Password))
            {
                //MainWindowViewModel.AutorisatedEmployee = _AutorisationService.AutorisatedUser;
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


    }
}
