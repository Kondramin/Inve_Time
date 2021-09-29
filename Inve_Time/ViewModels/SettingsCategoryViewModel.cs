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
    /// <summary>ViewModel of AutoSearchHelpersView</summary>
    class SettingsCategoryViewModel : ViewModel
    {
        private readonly IRepository<Category> _CategoryRepository;
        private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;
        private readonly IUserDialog _UserDialog;

        public SettingsCategoryViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        public SettingsCategoryViewModel(
            IRepository<Category> CategoryRepository,
            IRepository<CategorySearchWord> CategorySearchWordRepository,
            IUserDialog UserDialog
            )
        {
            _CategoryRepository = CategoryRepository;
            _CategorySearchWordRepository = CategorySearchWordRepository;
            _UserDialog = UserDialog;
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


        #region CategorySearchWordsListBox SelectedCategorySearchWord

        private CategorySearchWord _SelectedCategorySearchWord;
        /// <summary>SelectedCategorySearchWord in CategorySearchWordsListBox</summary>
        public CategorySearchWord SelectedCategorySearchWord
        {
            get => _SelectedCategorySearchWord;
            set => Set(ref _SelectedCategorySearchWord, value);
        }

        #endregion


        #region string NewFieldToCategorySearchWord

        private string _NewFieldToCategorySearchWord;
        /// <summary>New Field To CategorySearchWord</summary>
        public string NewFieldToCategorySearchWord
        {
            get => _NewFieldToCategorySearchWord;
            set => Set(ref _NewFieldToCategorySearchWord, value);
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
            SelectedCategory = null; //костыль
        }

        #endregion


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
            Category new_category = new();

            if (!_UserDialog.EditCategory(new_category)) return;

            _CategoryRepository.Add(new_category);

            _CategoryObservalCollection.Add(new_category);

            SelectedCategory = new_category;
        }

        #endregion


        #region Command ModifiCategoryCommand - Modifi category

        /// <summary>Modifi category</summary>
        private ICommand _ModifiCategoryCommand;

        /// <summary>Modifi category</summary>
        public ICommand ModifiCategoryCommand => _ModifiCategoryCommand
            ??= new LambdaCommand(OnModifiCategoryCommandExequted, CanModifiCategoryCommandExequt);

        /// <summary>Checking the possibility of execution - Modifi category</summary>
        public bool CanModifiCategoryCommandExequt(object p) => 
            p is Category category
            && SelectedCategory is not null
            && category is not null;

        /// <summary>Execution logic - Modifi category</summary>
        public void OnModifiCategoryCommandExequted(object p)
        {
            if (!(p is Category category)) return;

            if (!_UserDialog.EditCategory(category)) return;

            _CategoryRepository.Update(category);

            CategoryObservalCollection.Remove(category);
            CategoryObservalCollection.Add(category);
            SelectedCategory = category;
        }

        #endregion


        #region Command RemoveCategoryCommand - Remove category

        /// <summary>Remove category</summary>
        private ICommand _RemoveCategoryCommand;

        /// <summary>Remove category</summary>
        public ICommand RemoveCategoryCommand => _RemoveCategoryCommand
            ??= new LambdaCommand(OnRemoveCategoryCommandExequted, CanRemoveCategoryCommandExequt);

        /// <summary>Checking the possibility of execution - Remove category</summary>
        public bool CanRemoveCategoryCommandExequt(object p) =>
            p is Category category
            && SelectedCategory is not null
            && category is not null;

        /// <summary>Execution logic - Remove category</summary>
        public void OnRemoveCategoryCommandExequted(object p)
        {
            var category_to_remove = p ?? SelectedCategory;

            if (!(category_to_remove is Category category)) return;


            if (!_UserDialog.ConfirmInformation($"Вы уверены, что хотите удалить категорию {category.Name}?", "Удаление категории")) return;

            _CategoryRepository.Remove(category.Id);

            _CategoryObservalCollection.Remove(category);

            if (ReferenceEquals(SelectedCategory, category)) SelectedCategory = null;
        }

        #endregion




        #region Command AddNewCategorySearchWordCommand - Add new category

        /// <summary>Add new category</summary>
        private ICommand _AddNewCategorySearchWordCommand;

        /// <summary>Add new category</summary>
        public ICommand AddNewCategorySearchWordCommand => _AddNewCategorySearchWordCommand
            ??= new LambdaCommand(OnAddNewCategorySearchWordCommandExequted, CanAddNewCategorySearchWordCommandExequt);

        /// <summary>Checking the possibility of execution - Add new category</summary>
        public bool CanAddNewCategorySearchWordCommandExequt(object p) => 
            NewFieldToCategorySearchWord is not null
            && SelectedCategory is not null
            && !SelectedCategory.CategorySearchWords.Select(cat => cat.Name).Contains(NewFieldToCategorySearchWord);

        /// <summary>Execution logic - Add new category</summary>
        public void OnAddNewCategorySearchWordCommandExequted(object p)
        {
            CategorySearchWord new_categorySearchWord = new()
            {
                Name = NewFieldToCategorySearchWord,
                CategoryId = SelectedCategory.Id,
                Category = SelectedCategory
            };

            SelectedCategory.CategorySearchWords.Add(_CategorySearchWordRepository.Add(new_categorySearchWord));

            UpdateCategorySearchWordsView(SelectedCategory);

            SelectedCategorySearchWord = new_categorySearchWord;

            NewFieldToCategorySearchWord = null;
        }

        #endregion


        #region Command ModifiCategorySearchWordCommand - Modifi category

        /// <summary>Modifi category</summary>
        private ICommand _ModifiCategorySearchWordCommand;

        /// <summary>Modifi category</summary>
        public ICommand ModifiCategorySearchWordCommand => _ModifiCategorySearchWordCommand
            ??= new LambdaCommand(OnModifiCategorySearchWordCommandExequted, CanModifiCategorySearchWordCommandExequt);

        /// <summary>Checking the possibility of execution - Modifi category</summary>
        public bool CanModifiCategorySearchWordCommandExequt(object p) =>
            p is CategorySearchWord category
            && SelectedCategorySearchWord is not null
            && category is not null;

        /// <summary>Execution logic - Modifi category</summary>
        public void OnModifiCategorySearchWordCommandExequted(object p)
        {
            
        }

        #endregion


        #region Command RemoveCategorySearchWordCommand - Remove category

        /// <summary>Remove category</summary>
        private ICommand _RemoveCategorySearchWordCommand;

        /// <summary>Remove category</summary>
        public ICommand RemoveCategorySearchWordCommand => _RemoveCategorySearchWordCommand
            ??= new LambdaCommand(OnRemoveCategorySearchWordCommandExequted, CanRemoveCategorySearchWordCommandExequt);

        /// <summary>Checking the possibility of execution - Remove category</summary>
        public bool CanRemoveCategorySearchWordCommandExequt(object p) =>
            p is CategorySearchWord category
            && SelectedCategorySearchWord is not null
            && category is not null;

        /// <summary>Execution logic - Remove category</summary>
        public void OnRemoveCategorySearchWordCommandExequted(object p)
        {
           
        }

        #endregion


        #endregion


        #region HeplfulMethods

        private void UpdateCategorySearchWordsView(Category category)
        {
            SelectedCategory = null;
            SelectedCategory = category;
        }

        #endregion
    }
}
