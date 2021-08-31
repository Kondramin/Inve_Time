using Inve_Time.Commands.Base;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of ChangePasswordWindow</summary>
    class ChangePasswordWindowViewModel : ViewModel
    {
        private readonly IEditPasswordService _EditPasswordService;
        private readonly IAutorisationUserService _AutorisationUserService;

        public ChangePasswordWindowViewModel(
            int employeeId,
            IEditPasswordService EditPasswordService,
            IAutorisationUserService AutorisationUserService
            )
        {
            EmpId = employeeId;
            _EditPasswordService = EditPasswordService;
            _AutorisationUserService = AutorisationUserService;
        }

        public ChangePasswordWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }



        private int EmpId { get; set; }


        #region Commands


        #region Command ConfirmChangePasswordCommand - Add new employee

        /// <summary>Add new employee</summary>
        private ICommand _ConfirmChangePasswordCommand;

        /// <summary>Add new employee</summary>
        public ICommand ConfirmChangePasswordCommand => _ConfirmChangePasswordCommand
            ??= new LambdaCommand(OnConfirmChangePasswordCommandExequted, CanConfirmChangePasswordCommandExequt);

        /// <summary>Checking the possibility of execution - Add new employee</summary>
        public bool CanConfirmChangePasswordCommandExequt(object p) => true;

        /// <summary>Execution logic - Add new employee</summary>
        public void OnConfirmChangePasswordCommandExequted(object p)
        {
            if (p is not PasswordBox[] paswordBoxes) return;

            var window = App.CurrentWindow;

            if (!paswordBoxes[0].IsEnabled)
            {
                if (!_EditPasswordService.EditPassword(EmpId, " ", paswordBoxes[1].Password, paswordBoxes[2].Password))
                {
                    paswordBoxes[1].Password = "";
                    paswordBoxes[2].Password = "";
                    MessageBox.Show("Не совпадают пароли! Попробуйте снова.");
                    return;
                }

                window.DialogResult = true;
                window.Close();
            }

            if (!_AutorisationUserService.ValidatePassword(EmpId, paswordBoxes[0].Password))
            {
                paswordBoxes[0].Password = "";
                paswordBoxes[1].Password = "";
                paswordBoxes[2].Password = "";
                MessageBox.Show("Старый пароль не совпадает! Попробуйте снова.");
                return;
            }

            if (!_EditPasswordService.EditPassword(EmpId, paswordBoxes[0].Password, paswordBoxes[1].Password, paswordBoxes[2].Password))
            {
                paswordBoxes[0].Password = "";
                paswordBoxes[1].Password = "";
                paswordBoxes[2].Password = "";
                MessageBox.Show("Не совпадают пароли! Попробуйте снова.");
                return;
            }

            window.DialogResult = true;
            window.Close();

        }
        
        
        
        #endregion


        #endregion

    }
}
