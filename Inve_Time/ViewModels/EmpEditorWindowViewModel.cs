using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of EmpEditorWindow</summary>
    class EmpEditorWindowViewModel : ViewModel
    {
        private readonly IRepository<Position> _PositionRepository;
        private readonly IChangePasswordService _ChangePasswordService;

        public EmpEditorWindowViewModel(
            Employee emp,
            IRepository<Position> PositionRepository,
            IChangePasswordService ChangePasswordService
            )
        {
            EmpId = emp.Id;
            EmpSecondName = emp.SecondName;
            EmpName = emp.Name;
            EmpPatronymic = emp.Patronymic;
            EmpPhone = emp.Phone;
            EmpEmail = emp.Email;
            EmpLogin = emp.Login;
            SelectedPosition = emp.Position;
            _PositionRepository = PositionRepository;
            _ChangePasswordService = ChangePasswordService;
            PositionsCollection = new ObservableCollection<Position>(_PositionRepository.Items.ToArray());
        }

        public EmpEditorWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
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


        #region ObservableCollection<Position> PositionsCollection

        private ObservableCollection<Position> _PositionsCollection;
        /// <summary>Employee - Position</summary>
        public ObservableCollection<Position> PositionsCollection
        {
            get => _PositionsCollection;
            set => Set(ref _PositionsCollection, value);
        }
        
        #endregion


        #region Position SelectedPosition

        private Position _SelectedPosition;
        /// <summary>Selected Position in ComboBox</summary>
        public Position SelectedPosition
        {
            get => _SelectedPosition;
            set => Set(ref _SelectedPosition, value);
        }

        #endregion


        #region Command CreateOrModifiPasswordCommand - Add new employee

        /// <summary>Add new employee</summary>
        private ICommand _CreateOrModifiPasswordCommand;

        /// <summary>Add new employee</summary>
        public ICommand CreateOrModifiPasswordCommand => _CreateOrModifiPasswordCommand
            ??= new LambdaCommand(OnCreateOrModifiPasswordCommandExequted, CanCreateOrModifiPasswordCommandExequt);

        /// <summary>Checking the possibility of execution - Add new employee</summary>
        public bool CanCreateOrModifiPasswordCommandExequt(object p) => true;

        /// <summary>Execution logic - Add new employee</summary>
        public void OnCreateOrModifiPasswordCommandExequted(object p)
        {
            _ChangePasswordService.ChangePassword(EmpId);
        }

        #endregion

    }
}
