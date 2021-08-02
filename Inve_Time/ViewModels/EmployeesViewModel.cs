using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Models;
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



        public EmployeesViewModel(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }



        #region ObservableCollection<EmployeeBaseInfo> EmployeesCollection - collection of employees 

        private ObservableCollection<EmployeeBaseInfo> _EmployeesCollection;
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

                    _EmployeesViewSource.Filter += OnSecondNameFilter;
                    _EmployeesViewSource.View.Refresh();

                    OnPropertyChanged(nameof(EmployeesView));

                }
            }
        }

        private void OnSecondNameFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is EmployeeBaseInfo employeeBaseInfo) || string.IsNullOrEmpty(FilterFIOWord)) return;

            if (!(employeeBaseInfo.Fio.Contains(FilterFIOWord)))
                e.Accepted = false;
        }

        #endregion



        #region About Filters



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

        private CollectionViewSource _EmployeesViewSource;

        public ICollectionView EmployeesView => _EmployeesViewSource?.View;



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
                //.OrderBy(p => p.SecondName)
                .Select(e => new EmployeeBaseInfo
                {
                    Id = e.Id,
                    Name = e.Name,
                    SecondName = e.SecondName,
                    Patronymic = e.Patronymic,
                    Phone = e.Phone,
                    Email = e.Email,
                    PositionName = e.Position.Name
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



        #endregion

    }
}
