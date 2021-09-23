using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of AutoSearchHelpersView</summary>
    class SettingsCategoryViewModel : ViewModel
    {
        private readonly IRepository<Category> _CategoryRepository;
        private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;

        public SettingsCategoryViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        public SettingsCategoryViewModel(
            IRepository<Category> CategoryRepository,
            IRepository<CategorySearchWord> CategorySearchWordRepository
            )
        {
            _CategoryRepository = CategoryRepository;
            _CategorySearchWordRepository = CategorySearchWordRepository;
        }



        #region ObservableCollection<Category> CategoryObservalCollection - collection of Help category searchers 

        private ObservableCollection<Category> _CategoryObservalCollection;
        /// <summary>CategoryCollection - collection of Help category searchers</summary>
        public ObservableCollection<Category> CategoryObservalCollection
        {
            get => _CategoryObservalCollection;
            set
            {
                if (Set(ref _CategoryObservalCollection, value))
                {
                    _CategoryViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(Category.Name), ListSortDirection.Ascending)
                        }
                    };

                    _CategoryViewSource.Filter += NameFilter;

                    OnPropertyChanged(nameof(CategoryView));

                }
            }
        }

        private void NameFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not Category category || string.IsNullOrEmpty(FilterField)) return;

            if (category.Name == null || !category.Name.ToLower().Contains(FilterField.ToLower()))
                e.Accepted = false;
        }


        #endregion


        private CollectionViewSource _CategoryViewSource;


        public ICollectionView CategoryView => _CategoryViewSource?.View;


        #region CategoryListBox SelectedCategory

        private Category _SelectedCategory;
        /// <summary>SelectedCategory in CategoryListBox</summary>
        public Category SelectedCategory
        {
            get => _SelectedCategory;
            set => Set(ref _SelectedCategory, value);
        }

        #endregion


        #region CategorySearcherListBox SelectedCategorySearcher

        private Category _SelectedCategorySearcher;
        /// <summary>SelectedCategorySearcher in CategorySearcherListBox</summary>
        public Category SelectedCategorySearcher
        {
            get => _SelectedCategorySearcher;
            set => Set(ref _SelectedCategorySearcher, value);
        }

        #endregion


        #region string FilterField

        private string _FilterField;
        /// <summary>FilterField in AutoSearchHelpersView</summary>
        public string FilterField
        {
            get => _FilterField;
            set
            {
                if (Set(ref _FilterField, value))
                    _CategoryViewSource.View.Refresh();
            }

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


        //TODO: Realise CRUD to category


        #region Command AddNewCategoryCommand - Add new category

        /// <summary>Add new category</summary>
        private ICommand _AddNewCategoryCommand;

        /// <summary>Add new category</summary>
        public ICommand AddNewCategoryCommand => _AddNewCategoryCommand
            ??= new LambdaCommand(OnAddNewCategoryCommandExequted, CanAddNewCategoryCommandExequt);

        /// <summary>Checking the possibility of execution - Add new category</summary>
        public bool CanAddNewCategoryCommandExequt(object p) => true;

        /// <summary>Execution logic - Add new category</summary>
        public void OnAddNewCategoryCommandExequted(object p)
        {
            Category category = new();


        }

        #endregion


        #region Command ModifiCategoryCommand - Modifi category

        /// <summary>Modifi category</summary>
        private ICommand _ModifiCategoryCommand;

        /// <summary>Modifi category</summary>
        public ICommand ModifiCategoryCommand => _ModifiCategoryCommand
            ??= new LambdaCommand(OnModifiCategoryCommandExequted, CanModifiCategoryCommandExequt);

        /// <summary>Checking the possibility of execution - Modifi category</summary>
        public bool CanModifiCategoryCommandExequt(object p) => true;

        /// <summary>Execution logic - Modifi category</summary>
        public void OnModifiCategoryCommandExequted(object p)
        {
            
        }

        #endregion


        #region Command RemoveCategoryCommand - Remove category

        /// <summary>Remove category</summary>
        private ICommand _RemoveCategoryCommand;

        /// <summary>Remove category</summary>
        public ICommand RemoveCategoryCommand => _RemoveCategoryCommand
            ??= new LambdaCommand(OnRemoveCategoryCommandExequted, CanRemoveCategoryCommandExequt);

        /// <summary>Checking the possibility of execution - Remove category</summary>
        public bool CanRemoveCategoryCommandExequt(object p) => true;

        /// <summary>Execution logic - Remove category</summary>
        public void OnRemoveCategoryCommandExequted(object p)
        {
            
        }

        #endregion

        #endregion
    }
}
