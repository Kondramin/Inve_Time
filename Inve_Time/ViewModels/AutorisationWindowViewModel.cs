using Inve_Time.Commands.Base;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    internal class AutorisationWindowViewModel : ViewModel
    {
        //private readonly IAutorisationUserService _AutorisationUserService;


        //public AutorisationWindowViewModel(IAutorisationUserService autorisationService) => _AutorisationUserService = autorisationService;



        //#region string AutorisationWindow Title  = "Авторизуйтесь в системе"

        //private string _Title = "Авторизуйтесь в системе";
        ///// <summary>AutorisationWindow Title</summary>
        //public string Title
        //{
        //    get => _Title;
        //    set => Set(ref _Title, value);
        //}

        //#endregion


        //#region string AutorisationWindow LoginTextBox

        //private string _LoginTextBox;

        ///// <summary>AutorisationWindow LoginTextBox</summary>
        //public string LoginTextBox
        //{
        //    get => _LoginTextBox;
        //    set => Set(ref _LoginTextBox, value);
        //}

        //#endregion



        //#region Commands


        //#region Command AutorisationCommand - Autorisation in app 

        ///// <summary>Autorisation in app </summary>
        //private ICommand _AutorisationCommand;

        ///// <summary>Autorisation in app </summary>
        //public ICommand AutorisationCommand => _AutorisationCommand
        //    ??= new LambdaCommand(OnAutorisationCommandExequted);

        ///// <summary>Execution logic - Autorisation in app </summary>
        ///// <param name="p">PasswordBox</param>
        //public void OnAutorisationCommandExequted(object p)
        //{
        //    PasswordBox pwdBox = p as PasswordBox;

        //    if (_AutorisationUserService.ValidateLoginAndPassword(LoginTextBox, pwdBox.Password))
        //    {
        //        MainWindowViewModel.AutorisatedEmployee = _AutorisationUserService.AutorisatedUser;
        //        var mainWindow = new MainWindow();
        //        mainWindow.Show();
        //        Application.Current.MainWindow.Close();
        //        Application.Current.MainWindow = mainWindow;
        //    }
        //    else
        //    {
        //        LoginTextBox = "";
        //        pwdBox.Password = "";
        //    }
        //}

        //#endregion


        //#endregion


    }
}
