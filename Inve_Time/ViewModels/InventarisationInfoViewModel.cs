using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    class InventarisationInfoViewModel : ViewModel
    {
        private readonly IRepository<InventarisationEvent> _InventarisationEventRepos;
        private readonly IUserDialog _UserDialog;

        public InventarisationInfoViewModel(IRepository<InventarisationEvent> InventarisationEventRepos, IUserDialog UserDialog)
        {
            _InventarisationEventRepos = InventarisationEventRepos;
            _UserDialog = UserDialog;
        }

        public InventarisationInfoViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }



        #region ObservableCollection<InventarisationEvent> InventarisationEventObsCol - ObservableCollection of InventarisationEvents 

        private ObservableCollection<InventarisationEvent> _InventarisationEventObsCol;
        /// <summary>InventarisationEventObsCol - ObservableCollection of InventarisationEvents</summary>
        public ObservableCollection<InventarisationEvent> InventarisationEventObsCol
        {
            get => _InventarisationEventObsCol;
            set
            {
                if (Set(ref _InventarisationEventObsCol, value))
                {
                    _InventarisationEventViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(InventarisationEvent.DateOfEvent), ListSortDirection.Ascending)
                        }
                    };


                    //            _InventarisationEventViewSource.Filter += OnAnyFilter;
                    //            _InventarisationEventViewSource.Filter += OnFIOFilter;
                    //            _InventarisationEventViewSource.Filter += OnPhoneFilter;
                    //            _InventarisationEventViewSource.Filter += OnEmailFilter;
                    //            _InventarisationEventViewSource.Filter += OnPositionNameFilter;

                    _InventarisationEventViewSource.View.Refresh();

                    OnPropertyChanged(nameof(InventarisationEventView));

                }
            }
        }

        #endregion


        /// <summary>CollectoinViewSource of InventarisationEvent</summary>
        private CollectionViewSource _InventarisationEventViewSource;


        /// <summary>ICollection of InventarisationEvent. Using to show in DataGrid</summary>
        public ICollectionView InventarisationEventView => _InventarisationEventViewSource?.View;


        #region InventarisationEvent SelectedInventarisationEvent

        private InventarisationEvent _SelectedInventarisationEvent;
        /// <summary>SelectedInventarisationEvent in DataGrid</summary>
        public InventarisationEvent SelectedInventarisationEvent
        {
            get => _SelectedInventarisationEvent;
            set => Set(ref _SelectedInventarisationEvent, value);
        }

        #endregion



        #region About Filters


        //private void OnAnyFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEvent empBaseInfo || string.IsNullOrEmpty(FilterAnyWord)) return;

        //    if (empBaseInfo.Any == null || !empBaseInfo.Any.ToLower().Contains(FilterAnyWord.ToLower()))
        //        e.Accepted = false;
        //}

        //private void OnFIOFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEvent empBaseInfo || string.IsNullOrEmpty(FilterFIOWord)) return;

        //    if (empBaseInfo.Fio == null || !empBaseInfo.Fio.ToLower().Contains(FilterFIOWord.ToLower()))
        //        e.Accepted = false;
        //}

        //private void OnPhoneFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEvent empBaseInfo || string.IsNullOrEmpty(ConvertedFilterPhoneField())) return;

        //    if (empBaseInfo.Phone == null || !empBaseInfo.Phone.Contains(ConvertedFilterPhoneField()))
        //        e.Accepted = false;
        //}

        //private void OnEmailFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEvent empBaseInfo || string.IsNullOrEmpty(FilterEmailWord)) return;

        //    if (empBaseInfo.Email == null || !empBaseInfo.Email.ToLower().Contains(FilterEmailWord.ToLower()))
        //    {
        //        e.Accepted = false;
        //    }
        //}

        //private void OnPositionNameFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEvent empBaseInfo || string.IsNullOrEmpty(FilterPositionWord)) return;

        //    if ((empBaseInfo.Position == null) || (!empBaseInfo.Position.Name.ToLower().Contains(FilterPositionWord.ToLower())))
        //        e.Accepted = false;
        //}



        //#region Filter Fields


        //#region string EmployeeView FilterAny 

        //private string _FilterAnyWord;
        ///// <summary>EmployeeView FilterAny - searching word</summary>
        //public string FilterAnyWord
        //{
        //    get => _FilterAnyWord;
        //    set
        //    {
        //        if (Set(ref _FilterAnyWord, value))
        //            _InventarisationEventViewSource.View.Refresh();
        //    }
        //}

        //#endregion

        //#region string EmployeeView FilterFIO 

        //private string _FilterFIOWord;
        ///// <summary>EmployeeView FilterFIO - searching word</summary>
        //public string FilterFIOWord
        //{
        //    get => _FilterFIOWord;
        //    set
        //    {
        //        if (Set(ref _FilterFIOWord, value))
        //            _InventarisationEventViewSource.View.Refresh();
        //    }
        //}

        //#endregion

        //#region string EmployeeView FilterPhone 

        //private string _FilterPhoneWord;
        ///// <summary>EmployeeView FilterPhone - searching word</summary>
        //public string FilterPhoneWord
        //{
        //    get => _FilterPhoneWord;
        //    set
        //    {
        //        if (Set(ref _FilterPhoneWord, value))
        //            _InventarisationEventViewSource.View.Refresh();
        //    }
        //}

        //#endregion

        //#region string EmployeeView FilterEmail 

        //private string _FilterEmailWord;
        ///// <summary>EmployeeView FilterEmail - searching word</summary>
        //public string FilterEmailWord
        //{
        //    get => _FilterEmailWord;
        //    set
        //    {
        //        if (Set(ref _FilterEmailWord, value))
        //            _InventarisationEventViewSource.View.Refresh();
        //    }
        //}

        //#endregion

        //#region string EmployeeView FilterPosition 

        //private string _FilterPositionWord;
        ///// <summary>EmployeeView FilterPosition - searching word</summary>
        //public string FilterPositionWord
        //{
        //    get => _FilterPositionWord;
        //    set
        //    {
        //        if (Set(ref _FilterPositionWord, value))
        //            _InventarisationEventViewSource.View.Refresh();
        //    }
        //}

        //#endregion


        //#endregion



        //private string ConvertedFilterPhoneField()
        //{
        //    if (FilterPhoneWord is null) return null;

        //    var phone = FilterPhoneWord.Remove(0, 5);

        //    int fRemStart = 0;
        //    int fRemTrim = 0;


        //    for (int i = 0; i < phone.Length; i++)
        //    {
        //        if (!(phone[i] >= '0' && phone[i] <= '9'))
        //        {
        //            fRemTrim++;
        //        }
        //        else break;
        //    }

        //    if (fRemTrim == phone.Length) return null;


        //    phone = phone.Remove(fRemStart, fRemTrim);

        //    int sRemStart = phone.Length;
        //    int sRemTrim = 0;

        //    for (int j = phone.Length; j > 0; j--)
        //    {
        //        if (!(phone[j - 1] >= '0' && phone[j - 1] <= '9'))
        //        {
        //            sRemStart--;
        //            sRemTrim++;
        //        }
        //    }

        //    phone = phone.Remove(sRemStart, sRemTrim);

        //    return phone;
        //}



        #endregion



        #region Commands



        #region Command LoadInventarisationEventsCommand - Load InventarisationEvents from database

        /// <summary>Load InventarisationEvents from database</summary>
        private ICommand _LoadInventarisationEventsCommand;

        /// <summary>Load InventarisationEvents from database</summary>
        public ICommand LoadInventarisationEventsCommand => _LoadInventarisationEventsCommand
            ??= new LambdaCommandAsync(OnLoadInventarisationEventsCommandExequted);

        /// <summary>Execution logic - Load InventarisationEvents from database</summary>
        public async Task OnLoadInventarisationEventsCommandExequted(object p)
        {
            InventarisationEventObsCol = new ObservableCollection<InventarisationEvent>(await _InventarisationEventRepos.Items
            .OrderBy(i => i.DateOfEvent)
            .ToArrayAsync());
        }

        #endregion


        //#region Command CleanFilterFieldsCommand - Clean filter fields

        ///// <summary>Clean filter fields</summary>
        //private ICommand _CleanFilterFieldsCommand;

        ///// <summary>Clean filter fields</summary>
        //public ICommand CleanFilterFieldsCommand => _CleanFilterFieldsCommand
        //    ??= new LambdaCommand(OnCleanFilterFieldsCommandExequted);

        ///// <summary>Execution logic - Clean filter fields</summary>
        //public void OnCleanFilterFieldsCommandExequted(object p)
        //{
        //    FilterAnyWord = null;
        //    FilterFIOWord = null;
        //    FilterPhoneWord = null;
        //    FilterEmailWord = null;
        //    FilterPositionWord = null;
        //}

        //#endregion


        //#region Command AddNewEmployeeCommand - Add new employee

        ///// <summary>Add new employee</summary>
        //private ICommand _AddNewEmployeeCommand;

        ///// <summary>Add new employee</summary>
        //public ICommand AddNewEmployeeCommand => _AddNewEmployeeCommand
        //    ??= new LambdaCommand(OnAddNewEmployeeCommandExequted, CanAddNewEmployeeCommandExequt);

        ///// <summary>Checking the possibility of execution - Add new employee</summary>
        //public bool CanAddNewEmployeeCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 3;

        ///// <summary>Execution logic - Add new employee</summary>
        //public void OnAddNewEmployeeCommandExequted(object p)
        //{
        //    var new_employee = new Employee();

        //    if (!_UserDialog.EditEpmloyee(new_employee)) return;

        //    var empBase = new InventarisationEvent(_EmployeeRepository.Add(new_employee));

        //    _InventarisationEventObsCol.Add(empBase);

        //    SelectedInventarisationEvent = empBase;
        //}

        //#endregion


        //#region Command ModifiEmployeeCommand - Modifi employee

        ///// <summary>Modifi employee</summary>
        //private ICommand _ModifiEmployeeCommand;

        ///// <summary>Modifi employee</summary>
        //public ICommand ModifiEmployeeCommand => _ModifiEmployeeCommand
        //    ??= new LambdaCommand(OnModifiEmployeeCommandExequted, CanModifiEmployeeCommandExequt);

        ///// <summary>Checking the possibility of execution - Modifi employee</summary>
        //public bool CanModifiEmployeeCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 5;

        ///// <summary>Execution logic - Modifi employee</summary>
        //public void OnModifiEmployeeCommandExequted(object p)
        //{
        //    var emp_to_modifi = p ?? SelectedInventarisationEvent;

        //    if (emp_to_modifi is not InventarisationEvent empBase) return;

        //    var employee = _EmployeeRepository.Get(empBase.Id);

        //    if (!_UserDialog.EditEpmloyee(employee)) return;

        //    _EmployeeRepository.Update(employee);

        //    InventarisationEventObsCol.Remove(empBase);

        //    var newInventarisationEvent = new InventarisationEvent(employee);

        //    InventarisationEventObsCol.Add(newInventarisationEvent);

        //    SelectedInventarisationEvent = newInventarisationEvent;
        //}

        //#endregion


        //#region Command RemoveEmployeeCommand - Remove employee

        ///// <summary>Remove employee</summary>
        //private ICommand _RemoveEmployeeCommand;

        ///// <summary>Remove employee</summary>
        //public ICommand RemoveEmployeeCommand => _RemoveEmployeeCommand
        //    ??= new LambdaCommand(OnRemoveEmployeeCommandExequted, CanRemoveEmployeeCommandExequt);

        ///// <summary>Checking the possibility of execution - Remove employee</summary>
        //public bool CanRemoveEmployeeCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 7;

        ///// <summary>Execution logic - Remove employee</summary>
        //public void OnRemoveEmployeeCommandExequted(object p)
        //{
        //    var emp_to_remove = p ?? SelectedInventarisationEvent;

        //    if (emp_to_remove is not InventarisationEvent empBase) return;


        //    if (!_UserDialog.ConfirmInformation($"Вы уверены, что хотите удалить сотрудника {empBase.Fio}?", "Удаление сотрудника")) return;


        //    _EmployeeRepository.Remove(empBase.Id);

        //    _InventarisationEventObsCol.Remove(empBase);
        //    if (ReferenceEquals(SelectedInventarisationEvent, empBase)) SelectedInventarisationEvent = null;
        //}

        //#endregion



        #endregion

    }
}