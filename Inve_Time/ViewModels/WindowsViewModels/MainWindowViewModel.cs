using Inve_Time.Commands.Base;
using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Models;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using Inve_Time.ViewModels.ViewsViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace Inve_Time.ViewModels.WindowsViewModels
{
    /// <summary>ViewModel of MainWindow</summary>
    class MainWindowViewModel : ViewModel
    {
        //private readonly IRepository<Category> _CategoryRepository;
        //private readonly IRepository<InventarisationEvent> _InventarisationEventRepository;
        private readonly IRepository<Employee> _EmployeeRepository;
        //private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;
        //private readonly IRepository<Position> _PositionRepository;
        //private readonly IRepository<ProductInfo> _ProductBaseRepository;
        //private readonly IRepository<ProductInvented> _ProductInventedRepository;
        private readonly IUserDialog _UserDialog;


        public MainWindowViewModel(
        //    IRepository<Category> CategoryRepository,
        //    IRepository<InventarisationEvent> InventarisationEventRepository,
            IRepository<Employee> EmployeeRepository,
        //    IRepository<CategorySearchWord> CategorySearchWordRepository,
        //    IRepository<Position> PositionRepository,
        //    IRepository<ProductInfo> ProductBaseRepository,
        //    IRepository<ProductInvented> ProductInventedRepository,
            IUserDialog userDialog
            )
        {
            //    _CategoryRepository = CategoryRepository;
            //    _InventarisationEventRepository = InventarisationEventRepository;
            _EmployeeRepository = EmployeeRepository;
            //    _CategorySearchWordRepository = CategorySearchWordRepository;
            //    _PositionRepository = PositionRepository;
            //    _ProductBaseRepository = ProductBaseRepository;
            //    _ProductInventedRepository = ProductInventedRepository;
            _UserDialog = userDialog;
        }



        /// <summary>Info about autorisated employee</summary>
        public static EmployeeModel AutorisatedEmployeeModel;


        #region string Title  = "Inve_Time"

        private string _Title = "Inve_Time";
        /// <summary>MainWindow title</summary>
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
                return AutorisatedEmployeeModel.SecondName + " " + AutorisatedEmployeeModel.Name;
            }
        }


        /// <summary>StatusBar - Position of Employee</summary>
        public string StatusBarEmployeePositionName
        {
            get => AutorisatedEmployeeModel.PositionName;
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
            CurrentModel = new EmployeesViewModel(_EmployeeRepository, _UserDialog);
        }

        #endregion


        //#region Command ShowInventarisationViewCommand - Show InventarisationView

        ///// <summary>Show InventarisationView</summary>
        //private ICommand _ShowInventarisationViewCommand;

        ///// <summary>Show InventarisationView</summary>
        //public ICommand ShowInventarisationViewCommand => _ShowInventarisationViewCommand
        //    ??= new LambdaCommand(OnShowInventarisationViewCommandExequted, CanShowInventarisationViewCommandExequt);

        ///// <summary>Checking the possibility of execution - Show InventarisationView</summary>
        //public bool CanShowInventarisationViewCommandExequt(object p) => true;

        ///// <summary>Execution logic - Show InventarisationView</summary>
        //public void OnShowInventarisationViewCommandExequted(object p)
        //{
        //    CurrentModel = new InventarisationViewModel();
        //}

        //#endregion





        //#region Command ShowAutoSearchHelpersViewCommand - Show AutoSearchHelpersView

        ///// <summary>Show AutoSearchHelpersView</summary>
        //private ICommand _ShowAutoSearchHelpersViewCommand;

        ///// <summary>Show AutoSearchHelpersView</summary>
        //public ICommand ShowAutoSearchHelpersViewCommand => _ShowAutoSearchHelpersViewCommand
        //    ??= new LambdaCommand(OnShowAutoSearchHelpersViewCommandExequted, CanShowAutoSearchHelpersViewCommandExequt);

        ///// <summary>Checking the possibility of execution - Show AutoSearchHelpersView</summary>
        //public bool CanShowAutoSearchHelpersViewCommandExequt(object p) => true;

        ///// <summary>Execution logic - Show AutoSearchHelpersView</summary>
        //public void OnShowAutoSearchHelpersViewCommandExequted(object p)
        //{
        //    CurrentModel = new SettingsCategoryViewModel(_CategoryRepository, _CategorySearchWordRepository, _UserDialog);
        //}

        //#endregion


        //#region Command ShowProductsViewCommand - Show ProductsView

        ///// <summary>Show ProductsView</summary>
        //private ICommand _ShowProductsViewCommand;

        ///// <summary>Show ProductsView</summary>
        //public ICommand ShowProductsViewCommand => _ShowProductsViewCommand
        //    ??= new LambdaCommand(OnShowProductsViewCommandExequted, CanShowProductsViewCommandExequt);

        ///// <summary>Checking the possibility of execution - Show ProductsView</summary>
        //public bool CanShowProductsViewCommandExequt(object p) => true;

        ///// <summary>Execution logic - Show ProductsView</summary>
        //public void OnShowProductsViewCommandExequted(object p)
        //{
        //    CurrentModel = new ProductsViewModel(_ProductBaseRepository, _UserDialog);
        //}

        //#endregion


        //#region Command ShowInventarisationInfoViewCommand - Show ProductsView

        ///// <summary>Show ProductsView</summary>
        //private ICommand _ShowInventarisationInfoViewCommand;

        ///// <summary>Show ProductsView</summary>
        //public ICommand ShowInventarisationInfoViewCommand => _ShowInventarisationInfoViewCommand
        //    ??= new LambdaCommand(OnShowInventarisationInfoViewCommandExequted, CanShowInventarisationInfoViewCommandExequt);

        ///// <summary>Checking the possibility of execution - Show ProductsView</summary>
        //public bool CanShowInventarisationInfoViewCommandExequt(object p) => true;

        ///// <summary>Execution logic - Show ProductsView</summary>
        //public void OnShowInventarisationInfoViewCommandExequted(object p)
        //{
        //    CurrentModel = new InventarisationInfoViewModel(_InventarisationEventRepository, _UserDialog);
        //}

        //#endregion


        #endregion

    }
}
