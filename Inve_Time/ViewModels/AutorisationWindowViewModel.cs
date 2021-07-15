using Inve_Time.Commands.Base;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
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

        #region AutorisationCommand

        public ICommand AutorisationCommand { get; }

        private void OnAutorisationCommandExequted(object p)
        {
            PasswordBox pwdBox = p as PasswordBox;
            if(_AutorisationService.ValidateLoginAndPassword(LoginTextBox, pwdBox.Password))
            {
                MainWindowViewModel.MainWindowEmployee = _AutorisationService.AutorisatedUser;
                var mainWindow = new MainWindow();
                mainWindow.Show();
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




            #region Commands

            AutorisationCommand = new LambdaCommand(OnAutorisationCommandExequted);
            
            #endregion 
        }
    }
}
