using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Models;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of MainWindow</summary>
    class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Category> _CategoryRepository;
        private readonly IRepository<CurrentInventarisation> _CurrentInventarisationRepository;
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IRepository<HelpCategorySearch> _HelpCategorySearchRepository;
        private readonly IRepository<Position> _PositionRepository;
        private readonly IRepository<ProductBase> _ProductBaseRepository;
        private readonly IRepository<ProductInvented> _ProductInventedRepository;
        private readonly IUserDialog _UserDialog;


        public MainWindowViewModel(
            IRepository<Category> CategoryRepository,
            IRepository<CurrentInventarisation> CurrentInventarisationRepository,
            IRepository<Employee> EmployeeRepository,
            IRepository<HelpCategorySearch> HelpCategorySearchRepository,
            IRepository<Position> PositionRepository,
            IRepository<ProductBase> ProductBaseRepository,
            IRepository<ProductInvented> ProductInventedRepository,
            IUserDialog userDialog
            )
        {
            _CategoryRepository = CategoryRepository;
            _CurrentInventarisationRepository = CurrentInventarisationRepository;
            _EmployeeRepository = EmployeeRepository;
            _HelpCategorySearchRepository = HelpCategorySearchRepository;
            _PositionRepository = PositionRepository;
            _ProductBaseRepository = ProductBaseRepository;
            _ProductInventedRepository = ProductInventedRepository;
            _UserDialog = userDialog;
        }



        /// <summary>Info about autorisated user</summary>
        public static EmpBaseInfo AutorisatedEmployee;


        #region string MainWindow Title  = "Inve_Time"

        private string _Title = "Inve_Time";
        /// <summary>MainWindow Title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion


        /// <summary>StatusBar - Name of Employee</summary>
        public string StatusBarEmployeeName 
        {
            get
            {
                return AutorisatedEmployee.SecondName + " " + AutorisatedEmployee.Name;
            }
        }


        /// <summary>StatusBar - Position of Employee</summary>
        public string StatusBarEmployeePositionName 
        {
            get => AutorisatedEmployee.Position.Name; 
        }


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


        #region Command ReAutorisationInAppCommand - ReAutisated in App

        /// <summary>ReAutisated in App</summary>
        private ICommand _ReAutorisationInAppCommand;

        /// <summary>ReAutisated in App</summary>
        public ICommand ReAutorisationInAppCommand => _ReAutorisationInAppCommand
            ??= new LambdaCommand(OnReAutorisationInAppCommandExequted, CanReAutorisationInAppCommandExequt);

        /// <summary>Checking the possibility of execution - ReAutisated in App</summary>
        public bool CanReAutorisationInAppCommandExequt(object p) => true;

        /// <summary>Execution logic - ReAutisated in App</summary>
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
        public bool CanShowStartViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show StartView</summary>
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
        public bool CanShowInventarisationViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show InventarisationView</summary>
        public void OnShowInventarisationViewCommandExequted(object p)
        {
            CurrentModel = new InventarisationViewModel();
        }

        #endregion


        #region Command ShowEmployeesViewCommand - Show EmployeesView

        /// <summary>Show EmployeesView</summary>
        private ICommand _ShowEmployeesViewCommand;

        /// <summary>Show EmployeesView</summary>
        public ICommand ShowEmployeesViewCommand => _ShowEmployeesViewCommand
            ??= new LambdaCommand(OnShowEmployeesViewCommandExequted, CanShowEmployeesViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show EmployeesView</summary>
        public bool CanShowEmployeesViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show EmployeesView</summary>
        public void OnShowEmployeesViewCommandExequted(object p)
        {
            CurrentModel = new EmployeesViewModel(_EmployeeRepository, _PositionRepository, _UserDialog);
        }

        #endregion


        #region Command ShowAutoSearchHelpersViewCommand - Show AutoSearchHelpersView

        /// <summary>Show AutoSearchHelpersView</summary>
        private ICommand _ShowAutoSearchHelpersViewCommand;

        /// <summary>Show AutoSearchHelpersView</summary>
        public ICommand ShowAutoSearchHelpersViewCommand => _ShowAutoSearchHelpersViewCommand
            ??= new LambdaCommand(OnShowAutoSearchHelpersViewCommandExequted, CanShowAutoSearchHelpersViewCommandExequt);

        /// <summary>Checking the possibility of execution - Show AutoSearchHelpersView</summary>
        public bool CanShowAutoSearchHelpersViewCommandExequt(object p) => true;

        /// <summary>Execution logic - Show AutoSearchHelpersView</summary>
        public void OnShowAutoSearchHelpersViewCommandExequted(object p)
        {
            CurrentModel = new AutoSearchHelpersViewModel(_CategoryRepository);
        }

        #endregion


        #endregion

    }
}
