using Inve_Time.Commands.Base;
using Inve_Time.Interfaces.Services;
using Inve_Time.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inve_Time.ViewModels.WindowsViewModels.EditWindowsViewModels
{
    /// <summary>ViewModel of ChangePasswordWindow</summary>
    class ChangePasswordWindowViewModel : ViewModel
    {
        private readonly IEditPasswordService _EditPasswordService;

        public ChangePasswordWindowViewModel(
            int employeeId,
            IEditPasswordService EditPasswordService
            )
        {
            EmployeeId = employeeId;
            _EditPasswordService = EditPasswordService;
        }

        public ChangePasswordWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }



        private int EmployeeId { get; set; }


        #region Commands


        #region Command ChangePasswordCommand - Command to changing password

        /// <summary>Command to changing password</summary>
        private ICommand _ChangePasswordCommand;

        /// <summary>Command to changing password</summary>
        public ICommand ChangePasswordCommand => _ChangePasswordCommand
            ??= new LambdaCommand(OnChangePasswordCommandExequted, CanChangePasswordCommandExequt);

        /// <summary>Checking the possibility of execution - Command to changing password</summary>
        public bool CanChangePasswordCommandExequt(object p) => true;

        /// <summary>Execution logic - Command to changing password</summary>
        public void OnChangePasswordCommandExequted(object p)
        {
            if (p is not PasswordBox[] paswordBoxes) return;


            PasswordBox oldPasswordBox = paswordBoxes[0];
            PasswordBox newPasswordBox = paswordBoxes[1];
            PasswordBox confirmNewPasswordBox = paswordBoxes[2];


            var window = App.CurrentWindow;


            if (!_EditPasswordService.EditPassword(EmployeeId, oldPasswordBox.Password, newPasswordBox.Password, confirmNewPasswordBox.Password))
            {
                ClearPasswordBoxes(oldPasswordBox, newPasswordBox, confirmNewPasswordBox);
                MessageBox.Show("Не совпадают пароли! Попробуйте снова.");
                return;
            }

            window.DialogResult = true;
            window.Close();
            return;

        }

        private void ClearPasswordBoxes(PasswordBox oldPasswordBox, PasswordBox newPasswordBox, PasswordBox confirmNewPasswordBox)
        {
            oldPasswordBox.Password = "";
            newPasswordBox.Password = "";
            confirmNewPasswordBox.Password = "";
        }

        #endregion


        #endregion

    }
}
