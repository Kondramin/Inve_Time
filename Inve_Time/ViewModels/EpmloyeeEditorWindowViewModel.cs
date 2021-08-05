using Inve_Time.DataBase.dll.Entities;
using Inve_Time.ViewModels.Base;

namespace Inve_Time.ViewModels
{
    class EpmloyeeEditorWindowViewModel : ViewModel
    {




        public EpmloyeeEditorWindowViewModel(Employee employee)
        {
            EmployeeId = employee.Id;
            EmployeeSecondName = employee.SecondName;
            EmployeeName = employee.Name;
            EmployeePatronymic = employee.Patronymic;
            EmployeePhone = employee.Phone;
            EmployeeEmail = employee.Email;
            EmployeeLogin = employee.Login;
            EmployeePassword = employee.Password.Name;
            EmployeePositionName = employee.Position.Name;
        }


        #region Properties


        #region EmployeeDialogWindow int EmployeeId

        
        /// <summary>EmployeeDialogWindow EmployeeId</summary>
        public int EmployeeId { get; }


        #endregion


        #region EmployeeDialogWindow string EmployeeSecondName

        private string _EmployeeSecondName;
        /// <summary>EmployeeDialogWindow EmployeeSecondName</summary>
        public string EmployeeSecondName
        {
            get => _EmployeeSecondName;
            set => Set(ref _EmployeeSecondName, value);
        }

        #endregion


        #region EmployeeDialogWindow string EmployeeName

        private string _EmployeeName;
        /// <summary>EmployeeDialogWindow EmployeeName</summary>
        public string EmployeeName
        {
            get => _EmployeeName;
            set => Set(ref _EmployeeName, value);
        }

        #endregion


        #region EmployeeDialogWindow string EmployeePatronymic

        private string _EmployeePatronymic;
        /// <summary>EmployeeDialogWindow EmployeePatronymic</summary>
        public string EmployeePatronymic
        {
            get => _EmployeePatronymic;
            set => Set(ref _EmployeePatronymic, value);
        }

        #endregion


        #region EmployeeDialogWindow string EmployeePhone

        private string _EmployeePhone;
        /// <summary>EmployeeDialogWindow EmployeePhone</summary>
        public string EmployeePhone
        {
            get => _EmployeePhone;
            set => Set(ref _EmployeePhone, value);
        }

        #endregion


        #region EmployeeDialogWindow string EmployeeEmail

        private string _EmployeeEmail;
        /// <summary>EmployeeDialogWindow EmployeeEmail</summary>
        public string EmployeeEmail
        {
            get => _EmployeeEmail;
            set => Set(ref _EmployeeEmail, value);
        }

        #endregion


        #region EmployeeDialogWindow string EmployeeLogin

        private string _EmployeeLogin;
        /// <summary>EmployeeDialogWindow EmployeeLogin</summary>
        public string EmployeeLogin
        {
            get => _EmployeeLogin;
            set => Set(ref _EmployeeLogin, value);
        }

        #endregion


        #region EmployeeDialogWindow string EmployeePassword

        private string _EmployeePassword;
        /// <summary>EmployeeDialogWindow EmployeePassword</summary>
        public string EmployeePassword
        {
            get => _EmployeePassword;
            set => Set(ref _EmployeePassword, value);
        }

        #endregion


        #region EmployeeDialogWindow string EmployeePositionName

        private string _EmployeePositionName;
        /// <summary>EmployeeDialogWindow EmployeePositionName</summary>
        public string EmployeePositionName
        {
            get => _EmployeePositionName;
            set => Set(ref _EmployeePositionName, value);
        }

        #endregion


        #endregion


    }
}
