using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Models;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    class EmployeesViewModel : ViewModel
    {

        private IRepository<Employee> _EmployeeRepository;
        private readonly IUserDialog _UserDialog;

        public EmployeesViewModel(
            IRepository<Employee> employeeRepository,
            IUserDialog userDialog)
        {
            _EmployeeRepository = employeeRepository;
            _UserDialog = userDialog;
        }



        #region ObservableCollection<EmployeeBaseInfo> EmployeesCollection - collection of employees 

        private ObservableCollection<EmployeeBaseInfo> _EmployeesCollection = new ObservableCollection<EmployeeBaseInfo>();
        /// <summary>EmployeesCollection - collection of employees</summary>
        public ObservableCollection<EmployeeBaseInfo> EmployeesCollection
        {
            get => _EmployeesCollection;
            set
            { 
                if(Set(ref _EmployeesCollection, value))
                {
                    _EmployeesViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(EmployeeBaseInfo.Fio), ListSortDirection.Ascending)
                        }
                        
                    };

                    _EmployeesViewSource.Filter += OnAnyFilter;
                    _EmployeesViewSource.Filter += OnFIOFilter;
                    _EmployeesViewSource.Filter += OnPhoneFilter;
                    _EmployeesViewSource.Filter += OnEmailFilter;
                    _EmployeesViewSource.Filter += OnPositionNameFilter;
                    _EmployeesViewSource.View.Refresh();

                    OnPropertyChanged(nameof(EmployeesView));

                }
            }
        }


        #endregion


        private CollectionViewSource _EmployeesViewSource;


        public ICollectionView EmployeesView => _EmployeesViewSource?.View;


        #region EmployeeBaseInfo SelectedEmployee

        private EmployeeBaseInfo _SelectedEmployee;
        /// <summary>SelectedEmployee</summary>
        public EmployeeBaseInfo SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }

        #endregion



        #region About Filters


        private void OnAnyFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is EmployeeBaseInfo employeeBaseInfo) || string.IsNullOrEmpty(FilterAnyWord)) return;

            if (employeeBaseInfo.Any == null || !employeeBaseInfo.Any.ToLower().Contains(FilterAnyWord.ToLower()))
                e.Accepted = false;
        }

        private void OnFIOFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is EmployeeBaseInfo employeeBaseInfo) || string.IsNullOrEmpty(FilterFIOWord)) return;

            if (employeeBaseInfo.Fio == null || !employeeBaseInfo.Fio.ToLower().Contains(FilterFIOWord.ToLower()))
                e.Accepted = false;
        }

        private void OnPhoneFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is EmployeeBaseInfo employeeBaseInfo) || string.IsNullOrEmpty(FilterPhoneWord)) return;

            if (employeeBaseInfo.Phone == null || !employeeBaseInfo.Phone.ToLower().Contains(FilterPhoneWord.ToLower()))
                e.Accepted = false;
        }

        private void OnEmailFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is EmployeeBaseInfo employeeBaseInfo) || string.IsNullOrEmpty(FilterEmailWord)) return;

            if (employeeBaseInfo.Email == null || !employeeBaseInfo.Email.ToLower().Contains(FilterEmailWord.ToLower()))
            {
                e.Accepted = false;
            }
        }

        private void OnPositionNameFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is EmployeeBaseInfo employeeBaseInfo) || string.IsNullOrEmpty(FilterPositionWord)) return;

            if (employeeBaseInfo.Position.Name == null || !employeeBaseInfo.Position.Name.ToLower().Contains(FilterPositionWord.ToLower()))
                e.Accepted = false;
        }



        #region Filter Fields


        #region string EmployeeView FilterAny 

        private string _FilterAnyWord;
        /// <summary>EmployeeView FilterAny - searching word</summary>
        public string FilterAnyWord
        {
            get => _FilterAnyWord;
            set
            {
                if (Set(ref _FilterAnyWord, value))
                    _EmployeesViewSource.View.Refresh();
            }
        }

        #endregion

        #region string EmployeeView FilterFIO 

        private string _FilterFIOWord;
        /// <summary>EmployeeView FilterFIO - searching word</summary>
        public string FilterFIOWord
        {
            get => _FilterFIOWord;
            set 
            { 
                if(Set(ref _FilterFIOWord, value))
                    _EmployeesViewSource.View.Refresh();
            } 
        }

        #endregion

        #region string EmployeeView FilterPhone 

        private string _FilterPhoneWord;
        /// <summary>EmployeeView FilterPhone - searching word</summary>
        public string FilterPhoneWord
        {
            get => _FilterPhoneWord;
            set 
            {
                if (Set(ref _FilterPhoneWord, value))
                    _EmployeesViewSource.View.Refresh();
            }
        }

        #endregion

        #region string EmployeeView FilterEmail 

        private string _FilterEmailWord;
        /// <summary>EmployeeView FilterEmail - searching word</summary>
        public string FilterEmailWord
        {
            get => _FilterEmailWord;
            set 
            {
                if(Set(ref _FilterEmailWord, value))
                    _EmployeesViewSource.View.Refresh();
            }
        }

        #endregion

        #region string EmployeeView FilterPosition 

        private string _FilterPositionWord;
        /// <summary>EmployeeView FilterPosition - searching word</summary>
        public string FilterPositionWord
        {
            get => _FilterPositionWord;
            set
            {
                if(Set(ref _FilterPositionWord, value))
                    _EmployeesViewSource.View.Refresh();
            }
        }

        #endregion


        #endregion



        #endregion



        #region Commands



        #region Command LoadEmployeesCommand - Load Employees from database

        /// <summary>Load Employees from database</summary>
        private ICommand _LoadEmployeesCommand;


        /// <summary>Load Employees from database</summary>
        public ICommand LoadEmployeesCommand => _LoadEmployeesCommand
            ??= new LambdaCommandAsync(OnLoadEmployeesCommandExequted);

        /// <summary>Execution logic - Load Employees from database</summary>
        /// <param name="p"></param>
        public async Task OnLoadEmployeesCommandExequted(object p)
        {
            EmployeesCollection = new ObservableCollection<EmployeeBaseInfo>(await _EmployeeRepository.Items
            .Select(e => new EmployeeBaseInfo
            {
                Id = e.Id,
                Name = e.Name,
                SecondName = e.SecondName,
                Patronymic = e.Patronymic,
                Phone = e.Phone,
                Email = e.Email,
                Position = e.Position
            })
            .OrderBy(p => p.SecondName)
            .ThenBy(p => p.Name)
            .ThenBy(p => p.Patronymic)
            .ToArrayAsync());

        }

        #endregion


        #region Command CleanFilterFieldsCommand - Clean filter fields

        /// <summary>Clean filter fields</summary>
        private ICommand _CleanFilterFieldsCommand;

        /// <summary>Clean filter fields</summary>
        public ICommand CleanFilterFieldsCommand => _CleanFilterFieldsCommand
            ??= new LambdaCommand(OnCleanFilterFieldsCommandExequted, CanCleanFilterFieldsCommandExequt);

        /// <summary>Checking the possibility of execution - Clean filter fields</summary>
        /// <param name="p"></param>
        public bool CanCleanFilterFieldsCommandExequt(object p) => true;

        /// <summary>Execution logic - Clean filter fields</summary>
        /// <param name="p"></param>
        public void OnCleanFilterFieldsCommandExequted(object p)
        {
            FilterAnyWord = null;
            FilterFIOWord = null;
            FilterPhoneWord = null;
            FilterEmailWord = null;
            FilterPositionWord = null;
        }

        #endregion


        #region Command AddNewEmployeeCommand - Add new employee

        /// <summary>Add new employee</summary>
        private ICommand _AddNewEmployeeCommand;

        /// <summary>Add new employee</summary>
        public ICommand AddNewEmployeeCommand => _AddNewEmployeeCommand
            ??= new LambdaCommand(OnAddNewEmployeeCommandExequted, CanAddNewEmployeeCommandExequt);

        /// <summary>Checking the possibility of execution - Add new employee</summary>
        /// <param name="p"></param>
        public bool CanAddNewEmployeeCommandExequt(object p)
        {
            int requiredAccessLevel = 2;

            if (MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel < requiredAccessLevel) return false;
            else return true;
        }

        /// <summary>Execution logic - Add new employee</summary>
        /// <param name="p"></param>
        public void OnAddNewEmployeeCommandExequted(object p)
        {
            var new_employee = new Employee();

            if (_UserDialog.Edit(new_employee)) return;

           _EmployeesCollection.Add((EmployeeBaseInfo)_EmployeeRepository.Add(new_employee));
        }

        #endregion


        #region Command ModifiEmployeeCommand - Modifi employee

        /// <summary>Modifi employee</summary>
        private ICommand _ModifiEmployeeCommand;

        /// <summary>Modifi employee</summary>
        public ICommand ModifiEmployeeCommand => _ModifiEmployeeCommand
            ??= new LambdaCommand(OnModifiEmployeeCommandExequted, CanModifiEmployeeCommandExequt);

        /// <summary>Checking the possibility of execution - Modifi employee</summary>
        /// <param name="p"></param>
        public bool CanModifiEmployeeCommandExequt(object p)
        {
            int requiredAccessLevel = 2;


            if (MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel < requiredAccessLevel) return false;


            if (!(p is EmployeeBaseInfo) || (p is null) || (SelectedEmployee is null)) return false;
            else return true;
        }

        /// <summary>Execution logic - Modifi employee</summary>
        /// <param name="p"></param>
        public void OnModifiEmployeeCommandExequted(object p)
        {

        }

        #endregion


        #region Command RemoveEmployeeCommand - Remove employee

        /// <summary>Remove employee</summary>
        private ICommand _RemoveEmployeeCommand;

        /// <summary>Remove employee</summary>
        public ICommand RemoveEmployeeCommand => _RemoveEmployeeCommand
            ??= new LambdaCommand(OnRemoveEmployeeCommandExequted, CanRemoveEmployeeCommandExequt);

        /// <summary>Checking the possibility of execution - Remove employee</summary>
        /// <param name="p"></param>
        public bool CanRemoveEmployeeCommandExequt(object p)
        {
            int requiredAccessLevel = 5;


            if (MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel < requiredAccessLevel) return false;


            if (!(p is EmployeeBaseInfo) || (p is null) || (SelectedEmployee is null)) return false;
            else return true;
        }

        /// <summary>Execution logic - Remove employee</summary>
        /// <param name="p"></param>
        public void OnRemoveEmployeeCommandExequted(object p)
        {
            var employee_to_remove = p ?? SelectedEmployee;
        }

        #endregion



        #endregion

    }
}
