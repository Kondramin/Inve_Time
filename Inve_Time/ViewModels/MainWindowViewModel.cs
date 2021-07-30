using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace Inve_Time.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public static Employee MainWindowEmployee;


        private readonly IRepository<Category> _CategoryRepository;
        private readonly IRepository<Employee> _EmployeeRepository;




        #region string MainWindow Title  = "Inve_Time"

        private string _Title = "Inve_Time";
        /// <summary>MainWindow Title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion


        #region string MainWindow StatusBarEmployeeName

        private string _StatusBarEmployeeName = MainWindowEmployee.Name;

        /// <summary>MainWindow StatusBarEmployeeName</summary>
        public string StatusBarEmployeeName
        {
            get => _StatusBarEmployeeName;
            set => Set(ref _StatusBarEmployeeName, value);
        }

        #endregion


        #region string MainWindow StatusBarEmployeePositionName

        private string _StatusBarEmployeePositionName = MainWindowEmployee.Position.Name;

        /// <summary>MainWindow StatusBarEmployeePositionName</summary>
        public string StatusBarEmployeePositionName
        {
            get => _StatusBarEmployeePositionName;
            set => Set(ref _StatusBarEmployeePositionName, value);
        }

        #endregion


        #region ViewModel MainWindow CurrentModel

        private ViewModel _CurrentModel;
        /// <summary>MainWindow CurrentModel</summary>
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            set => Set(ref _CurrentModel, value);
        }

        #endregion



        #region Commands

        #region Command ReAutorisationInAppCommand - ReAutisated in application

        /// <summary>ReAutisated in application</summary>
        private ICommand _ReAutorisationInAppCommand;

        /// <summary>ReAutisated in application</summary>
        public ICommand ReAutorisationInAppCommand => _ReAutorisationInAppCommand
            ??= new LambdaCommand(OnReAutorisationInAppCommandExequted, CanReAutorisationInAppCommandExequt);

        /// <summary>Checking the possibility of execution - ReAutisated in application</summary>
        /// <param name="p"></param>
        public bool CanReAutorisationInAppCommandExequt(object p) => true;

        /// <summary>Execution logic - ReAutisated in application</summary>
        /// <param name="p"></param>
        public void OnReAutorisationInAppCommandExequted(object p)
        {
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            Application.Current.Shutdown();
        }


        #endregion

        #region Command ShowStartViewCommand - Show StartView

        /// <summary>Show StartView</summary>
        private ICommand _ShowStartViewCommand;

        /// <summary>Show StartView</summary>
        public ICommand ShowStartViewCommand => _ShowStartViewCommand
            ??= new LambdaCommand(OnShowStartViewCommandExequted, CanShowStartViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show StartView</summary>
        /// <param name="p"></param>
        public bool CanShowStartViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show StartView</summary>
        /// <param name="p"></param>
        public void OnShowStartViewCommandExequted(object p)
        {
            CurrentModel = new StartViewModel();
        }


        #endregion

        #region Command ShowInventarisationViewCommand - Show InventarisationView

        /// <summary>Show InventarisationView</summary>
        private ICommand _ShowInventarisationViewCommand;

        /// <summary>Show InventarisationView</summary>
        public ICommand ShowInventarisationViewCommand => _ShowInventarisationViewCommand
            ??= new LambdaCommand(OnShowInventarisationViewCommandExequted, CanShowInventarisationViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show InventarisationView</summary>
        /// <param name="p"></param>
        public bool CanShowInventarisationViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show InventarisationView</summary>
        /// <param name="p"></param>
        public void OnShowInventarisationViewCommandExequted(object p)
        {
            CurrentModel = new InventarisationViewModel();
        }


        #endregion

        #region Command ShowSettingsAutoSearchCategoryViewCommand - Show SettingsAutoSearchCategoryView

        /// <summary>Show SettingsAutoSearchCategoryView</summary>
        private ICommand _ShowSettingsAutoSearchCategoryViewCommand;


        /// <summary>Show SettingsAutoSearchCategoryView</summary>
        public ICommand ShowSettingsAutoSearchCategoryViewCommand => _ShowSettingsAutoSearchCategoryViewCommand
            ??= new LambdaCommand(OnShowSettingsAutoSearchCategoryViewCommandExequted, CanShowSettingsAutoSearchCategoryViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show SettingsAutoSearchCategoryView</summary>
        /// <param name="p"></param>
        public bool CanShowSettingsAutoSearchCategoryViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show SettingsAutoSearchCategoryView</summary>
        /// <param name="p"></param>
        public void OnShowSettingsAutoSearchCategoryViewCommandExequted(object p)
        {
            CurrentModel = new SettingsAutoSearchCategoryViewModel(_CategoryRepository);
        }


        #endregion

        #region Command ShowEmployeesViewCommand - Show EmployeesView

        /// <summary>Show EmployeesView</summary>
        private ICommand _ShowEmployeesViewCommand;


        /// <summary>Show EmployeesView</summary>
        public ICommand ShowEmployeesViewCommand => _ShowEmployeesViewCommand
            ??= new LambdaCommand(OnShowEmployeesViewCommandExequted, CanShowEmployeesViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show EmployeesView</summary>
        /// <param name="p"></param>
        public bool CanShowEmployeesViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show EmployeesView</summary>
        /// <param name="p"></param>
        public void OnShowEmployeesViewCommandExequted(object p)
        {
            CurrentModel = new EmployeesViewModel(_EmployeeRepository);
        }


        #endregion

        #endregion




        public MainWindowViewModel(
            IRepository<Category> CategoryRepository,
            IRepository<Employee> EmployeeRepository
            )
        {
            _CategoryRepository = CategoryRepository;
            _EmployeeRepository = EmployeeRepository;
        }
    }
}
