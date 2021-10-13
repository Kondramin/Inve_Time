using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Models;
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



        #region ObservableCollection<InventarisationEventModel> InventarisationEventModelObsCol - ObservableCollection of InventarisationEventModels 

        private ObservableCollection<InventarisationEventModel> _InventarisationEventModelObsCol = new();
        /// <summary>InventarisationEventModelObsCol - ObservableCollection of InventarisationEventModels</summary>
        public ObservableCollection<InventarisationEventModel> InventarisationEventModelObsCol
        {
            get => _InventarisationEventModelObsCol;
            set
            {
                if (Set(ref _InventarisationEventModelObsCol, value))
                {
                    _InventarisationEventModelViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(InventarisationEventModel.DateOfEvent), ListSortDirection.Ascending)
                        }
                    };


                    //            _InventarisationEventModelViewSource.Filter += OnAnyFilter;
                    //            _InventarisationEventModelViewSource.Filter += OnFIOFilter;
                    //            _InventarisationEventModelViewSource.Filter += OnPhoneFilter;
                    //            _InventarisationEventModelViewSource.Filter += OnEmailFilter;
                    //            _InventarisationEventModelViewSource.Filter += OnPositionNameFilter;

                    _InventarisationEventModelViewSource.View.Refresh();

                    OnPropertyChanged(nameof(InventarisationEventModelView));

                }
            }
        }

        #endregion


        /// <summary>CollectoinViewSource of InventarisationEventModel</summary>
        private CollectionViewSource _InventarisationEventModelViewSource;


        /// <summary>ICollection of InventarisationEventModel. Using to show in DataGrid</summary>
        public ICollectionView InventarisationEventModelView => _InventarisationEventModelViewSource?.View;


        #region InventarisationEventModel SelectedInventarisationEventModel

        private InventarisationEventModel _SelectedInventarisationEventModel;
        /// <summary>SelectedInventarisationEventModel in DataGrid</summary>
        public InventarisationEventModel SelectedInventarisationEventModel
        {
            get => _SelectedInventarisationEventModel;
            set => Set(ref _SelectedInventarisationEventModel, value);
        }

        #endregion



        #region About Filters


        //private void OnAnyFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEventModel empBaseInfo || string.IsNullOrEmpty(FilterAnyWord)) return;

        //    if (empBaseInfo.Any == null || !empBaseInfo.Any.ToLower().Contains(FilterAnyWord.ToLower()))
        //        e.Accepted = false;
        //}

        //private void OnFIOFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEventModel empBaseInfo || string.IsNullOrEmpty(FilterFIOWord)) return;

        //    if (empBaseInfo.Fio == null || !empBaseInfo.Fio.ToLower().Contains(FilterFIOWord.ToLower()))
        //        e.Accepted = false;
        //}

        //private void OnPhoneFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEventModel empBaseInfo || string.IsNullOrEmpty(ConvertedFilterPhoneField())) return;

        //    if (empBaseInfo.Phone == null || !empBaseInfo.Phone.Contains(ConvertedFilterPhoneField()))
        //        e.Accepted = false;
        //}

        //private void OnEmailFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEventModel empBaseInfo || string.IsNullOrEmpty(FilterEmailWord)) return;

        //    if (empBaseInfo.Email == null || !empBaseInfo.Email.ToLower().Contains(FilterEmailWord.ToLower()))
        //    {
        //        e.Accepted = false;
        //    }
        //}

        //private void OnPositionNameFilter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item is not InventarisationEventModel empBaseInfo || string.IsNullOrEmpty(FilterPositionWord)) return;

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
        //            _InventarisationEventModelViewSource.View.Refresh();
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
        //            _InventarisationEventModelViewSource.View.Refresh();
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
        //            _InventarisationEventModelViewSource.View.Refresh();
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
        //            _InventarisationEventModelViewSource.View.Refresh();
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
        //            _InventarisationEventModelViewSource.View.Refresh();
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



        #region Command LoadInventarisationEventModelsCommand - Load InventarisationEventModels from database

        /// <summary>Load InventarisationEventModels from database</summary>
        private ICommand _LoadInventarisationEventModelsCommand;

        /// <summary>Load InventarisationEventModels from database</summary>
        public ICommand LoadInventarisationEventModelsCommand => _LoadInventarisationEventModelsCommand
            ??= new LambdaCommandAsync(OnLoadInventarisationEventModelsCommandExequted);

        /// <summary>Execution logic - Load InventarisationEventModels from database</summary>
        public async Task OnLoadInventarisationEventModelsCommandExequted(object p)
        {
            foreach(var inventEvent in await _InventarisationEventRepos.Items.OrderBy(i => i.DateOfEvent).ToArrayAsync())
            {
                InventarisationEventModelObsCol.Add(new InventarisationEventModel(inventEvent));
            }
        }

        #endregion


        #region Command CleanFilterFieldsCommand - Clean filter fields

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

        #endregion


        #region Command AddInventarisationEventCommand - Add new InventarisationEvent

        /// <summary>Add new InventarisationEvent</summary>
        private ICommand _AddInventarisationEventCommand;

        /// <summary>Add new InventarisationEvent</summary>
        public ICommand AddInventarisationEventCommand => _AddInventarisationEventCommand
            ??= new LambdaCommand(OnAddInventarisationEventCommandExequted, CanAddInventarisationEventCommandExequt);

        /// <summary>Checking the possibility of execution - Add new InventarisationEvent</summary>
        public bool CanAddInventarisationEventCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 3;

        /// <summary>Execution logic - Add new InventarisationEvent</summary>
        public void OnAddInventarisationEventCommandExequted(object p)
        {
            var new_InventarisationEvent = new InventarisationEvent();

            //if (!_UserDialog.EditEpmloyee(new_InventarisationEvent)) return;

            var InventarisationEventModel = new InventarisationEventModel(_InventarisationEventRepos.Add(new_InventarisationEvent));

            _InventarisationEventModelObsCol.Add(InventarisationEventModel);

            SelectedInventarisationEventModel = InventarisationEventModel;
        }

        #endregion


        //#region Command ModifiInventarisationEventCommand - Modifi InventarisationEvent

        ///// <summary>Modifi InventarisationEvent</summary>
        //private ICommand _ModifiInventarisationEventCommand;

        ///// <summary>Modifi InventarisationEvent</summary>
        //public ICommand ModifiInventarisationEventCommand => _ModifiInventarisationEventCommand
        //    ??= new LambdaCommand(OnModifiInventarisationEventCommandExequted, CanModifiInventarisationEventCommandExequt);

        ///// <summary>Checking the possibility of execution - Modifi InventarisationEvent</summary>
        //public bool CanModifiInventarisationEventCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 5;

        ///// <summary>Execution logic - Modifi InventarisationEvent</summary>
        //public void OnModifiInventarisationEventCommandExequted(object p)
        //{
        //    var emp_to_modifi = p ?? SelectedInventarisationEventModel;

        //    if (emp_to_modifi is not InventarisationEventModel empBase) return;

        //    var InventarisationEvent = _EmployeeRepository.Get(empBase.Id);

        //    if (!_UserDialog.EditEpmloyee(InventarisationEvent)) return;

        //    _EmployeeRepository.Update(InventarisationEvent);

        //    InventarisationEventModelObsCol.Remove(empBase);

        //    var newInventarisationEventModel = new InventarisationEventModel(InventarisationEvent);

        //    InventarisationEventModelObsCol.Add(newInventarisationEventModel);

        //    SelectedInventarisationEventModel = newInventarisationEventModel;
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
        //    var emp_to_remove = p ?? SelectedInventarisationEventModel;

        //    if (emp_to_remove is not InventarisationEventModel empBase) return;


        //    if (!_UserDialog.ConfirmInformation($"Вы уверены, что хотите удалить сотрудника {empBase.Fio}?", "Удаление сотрудника")) return;


        //    _EmployeeRepository.Remove(empBase.Id);

        //    _InventarisationEventModelObsCol.Remove(empBase);
        //    if (ReferenceEquals(SelectedInventarisationEventModel, empBase)) SelectedInventarisationEventModel = null;
        //}

        //#endregion



        #endregion

    }
}