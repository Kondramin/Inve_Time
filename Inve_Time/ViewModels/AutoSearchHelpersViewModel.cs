using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of AutoSearchHelpersView</summary>
    class AutoSearchHelpersViewModel : ViewModel
    {
        private readonly IRepository<Category> _CategoryRepository;
        private readonly IRepository<HelpCategorySearch> _HelpCategorySearchRepository;


        public AutoSearchHelpersViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        public AutoSearchHelpersViewModel(
            IRepository<Category> CategoryRepository,
            IRepository<HelpCategorySearch> HelpCategorySearchRepository
            )
        {
            _CategoryRepository = CategoryRepository;
            _HelpCategorySearchRepository = HelpCategorySearchRepository;
        }



        #region ObservableCollection<Category> CategoryObservalCollection - collection of Help category searchers 

        private ObservableCollection<Category> _CategoryObservalCollection;
        /// <summary>CategoryCollection - collection of Help category searchers</summary>
        public ObservableCollection<Category> CategoryObservalCollection
        {
            get => _CategoryObservalCollection;
            set => Set(ref _CategoryObservalCollection, value);
            //{
            //    if (Set(ref _HelpCategorySearchCollection, value))
            //    {
            //        _EmployeesViewSource = new CollectionViewSource
            //        {
            //            Source = value,
            //            SortDescriptions =
            //            {
            //                new SortDescription(nameof(EmpBaseInfo.Fio), ListSortDirection.Ascending)
            //            }

            //        };

            //        _EmployeesViewSource.Filter += OnAnyFilter;
            //        _EmployeesViewSource.Filter += OnFIOFilter;
            //        _EmployeesViewSource.Filter += OnPhoneFilter;
            //        _EmployeesViewSource.Filter += OnEmailFilter;
            //        _EmployeesViewSource.Filter += OnPositionNameFilter;
            //        _EmployeesViewSource.View.Refresh();

            //        OnPropertyChanged(nameof(EmployeesView));

            //    }
            //}
        }

        #endregion


        #region SelectedCategory SelectedCategory

        private Category _SelectedCategory;
        /// <summary>SelectedCategory in ListBox</summary>
        public Category SelectedCategory
        {
            get => _SelectedCategory;
            set => Set(ref _SelectedCategory, value);
        }

        #endregion




        #region Commands


        #region Command LoadCategoryCommand - Load Category from database

        /// <summary>Load Category from database</summary>
        private ICommand _LoadCategoryCommand;

        /// <summary>Load Category from database</summary>
        public ICommand LoadCategoryCommand => _LoadCategoryCommand
            ??= new LambdaCommandAsync(OnLoadCategoryCommandExequted);

        /// <summary>Execution logic - Load Category from database</summary>
        public async Task OnLoadCategoryCommandExequted(object p)
        {
            CategoryObservalCollection = new ObservableCollection<Category>(await _CategoryRepository.Items.ToArrayAsync());
        }

        #endregion


        #endregion
    }
}
