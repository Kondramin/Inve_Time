using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of ChangePasswordWindow</summary>
    class ChangePasswordWindowViewModel : ViewModel
    {

        //public ChangePasswordWindowViewModel(
            
        //    )
        //{
        //}
        
        public ChangePasswordWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }



        
        
        
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
            
        }

        #endregion


        #endregion

    }
}
