using Inve_Time.DataBase.dll.Entities;
using Inve_Time.ViewModels.Base;

namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of EmpEditorWindow</summary>
    class EmpEditorWindowViewModel : ViewModel
    {
        public EmpEditorWindowViewModel(Employee emp)
        {
            EmpId = emp.Id;
            EmpSecondName = emp.SecondName;
            EmpName = emp.Name;
            EmpPatronymic = emp.Patronymic;
            EmpPhone = emp.Phone;
            EmpEmail = emp.Email;
            EmpLogin = emp.Login;
        }



        /// <summary>EmployeeId</summary>
        public int EmpId { get; }


        #region string EmpSecondName

        private string _EmpSecondName;
        /// <summary>Employee - SecondName</summary>
        public string EmpSecondName
        {
            get => _EmpSecondName;
            set => Set(ref _EmpSecondName, value);
        }

        #endregion


        #region string EmpName

        private string _EmpName;
        /// <summary>Employee - Name</summary>
        public string EmpName
        {
            get => _EmpName;
            set => Set(ref _EmpName, value);
        }

        #endregion


        #region string EmpPatronymic

        private string _EmpPatronymic;
        /// <summary>Employee - Patronymic</summary>
        public string EmpPatronymic
        {
            get => _EmpPatronymic;
            set => Set(ref _EmpPatronymic, value);
        }

        #endregion


        #region string EmpPhone

        private string _EmpPhone;
        /// <summary>Employee - Phone</summary>
        public string EmpPhone
        {
            get => _EmpPhone;
            set => Set(ref _EmpPhone, value);
        }

        #endregion


        #region string EmpEmail

        private string _EmpEmail;
        /// <summary>Employee - Email</summary>
        public string EmpEmail
        {
            get => _EmpEmail;
            set => Set(ref _EmpEmail, value);
        }

        #endregion


        #region string EmpLogin

        private string _EmpLogin;
        /// <summary>Employee - Login</summary>
        public string EmpLogin
        {
            get => _EmpLogin;
            set => Set(ref _EmpLogin, value);
        }

        #endregion


        #region string EmpPositionName

        private string _EmpPositionName;
        /// <summary>Employee - PositionName</summary>
        public string EmpPositionName
        {
            get => _EmpPositionName;
            set => Set(ref _EmpPositionName, value);
        }

        #endregion
    }
}
