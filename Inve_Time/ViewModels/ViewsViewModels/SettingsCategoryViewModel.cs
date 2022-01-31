using Inve_Time.ViewModels.Base;

namespace Inve_Time.ViewModels.ViewsViewModels
{
    /// <summary>ViewModel of AutoSearchHelpersView</summary>
    class SettingsCategoryViewModel : ViewModel
    {
    //    //private readonly IRepository<Category> _CategoryRepository;
    //    //private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;
    //    private readonly IUserDialog _UserDialog;

    //    public SettingsCategoryViewModel()
    //    {
    //        if (!App.IsDesignTime)
    //            throw new InvalidOperationException("Ctor not for Runtime!!!");
    //    }

    //    public SettingsCategoryViewModel(
    //        //IRepository<Category> CategoryRepository,
    //        //IRepository<CategorySearchWord> CategorySearchWordRepository,
    //        IUserDialog UserDialog
    //        )
    //    {
    //        //_CategoryRepository = CategoryRepository;
    //        //_CategorySearchWordRepository = CategorySearchWordRepository;
    //        _UserDialog = UserDialog;
    //    }



    //    #region ObservableCollection<CategoryModel> CategoryModelObsColl - ObservableCollection of CategoryModels

    //    private ObservableCollection<CategoryModel> _CategoryModelObsColl;
    //    /// <summary>CategoryModelObservableCollection</summary>
    //    public ObservableCollection<CategoryModel> CategoryModelObsColl
    //    {
    //        get => _CategoryModelObsColl;
    //        set
    //        {
    //            if (Set(ref _CategoryModelObsColl, value))
    //            {
    //                _CategoryModelViewSource = new CollectionViewSource
    //                {
    //                    Source = value,
    //                    SortDescriptions =
    //                    {
    //                        new SortDescription(nameof(CategoryModel.Name), ListSortDirection.Ascending)
    //                    }
    //                };

    //                _CategoryModelViewSource.Filter += CategoryModelNameFilter;

    //                OnPropertyChanged(nameof(CategoryModelView));

    //            }
    //        }
    //    }

    //    private void CategoryModelNameFilter(object sender, FilterEventArgs e)
    //    {
    //        if (e.Item is not CategoryModel category || string.IsNullOrEmpty(CategoryModelNameFilterField)) return;

    //        if (category.Name == null || !category.Name.ToLower().Contains(CategoryModelNameFilterField.ToLower()))
    //            e.Accepted = false;
    //    }


    //    #endregion


    //    #region string CategoryModelNameFilterField

    //    private string _CategoryModelNameFilterField;
    //    /// <summary>CategoryModelNameFilterField</summary>
    //    public string CategoryModelNameFilterField
    //    {
    //        get => _CategoryModelNameFilterField;
    //        set
    //        {
    //            if (Set(ref _CategoryModelNameFilterField, value))
    //                _CategoryModelViewSource.View.Refresh();
    //        }

    //    }

    //    #endregion



    //    private CollectionViewSource _CategoryModelViewSource;


    //    public ICollectionView CategoryModelView => _CategoryModelViewSource?.View;


    //    #region CategoryModelListBox SelectedCategoryModel

    //    private CategoryModel _SelectedCategoryModel;
    //    /// <summary>SelectedCategoryModel in CategoryModelListBox</summary>
    //    public CategoryModel SelectedCategoryModel
    //    {
    //        get => _SelectedCategoryModel;
    //        set => Set(ref _SelectedCategoryModel, value);
    //    }

    //    #endregion


    //    #region CategorySearchWordsListBox SelectedCategorySearchWord

    //    private CategorySearchWord _SelectedCategorySearchWord;
    //    /// <summary>SelectedCategorySearchWord in CategorySearchWordsListBox</summary>
    //    public CategorySearchWord SelectedCategorySearchWord
    //    {
    //        get => _SelectedCategorySearchWord;
    //        set => Set(ref _SelectedCategorySearchWord, value);
    //    }

    //    #endregion


    //    #region string NewFieldToCategorySearchWord

    //    private string _NewFieldToCategorySearchWord;
    //    /// <summary>New Field To CategorySearchWord</summary>
    //    public string NewFieldToCategorySearchWord
    //    {
    //        get => _NewFieldToCategorySearchWord;
    //        set => Set(ref _NewFieldToCategorySearchWord, value);
    //    }

    //    #endregion


    //    #region string EditFieldToCategorySearchWord

    //    private string _EditFieldToCategorySearchWord;
    //    /// <summary>Edit Field To CategoryModelSearchWord</summary>
    //    public string EditFieldToCategorySearchWord
    //    {
    //        get => _EditFieldToCategorySearchWord;
    //        set => Set(ref _EditFieldToCategorySearchWord, value);
    //    }

    //    #endregion




    //    #region Commands


    //    #region Command LoadCategoryModelCommand - Load Category from database to CategoryModel

    //    /// <summary>Load Category from database to CategoryModel</summary>
    //    private ICommand _LoadCategoryModelCommand;

    //    /// <summary>Load Category from database to CategoryModel</summary>
    //    public ICommand LoadCategoryModelCommand => _LoadCategoryModelCommand
    //        ??= new LambdaCommandAsync(OnLoadCategoryModelCommandExequted);

    //    /// <summary>Execution logic - Load Category from database to CategoryModel</summary>
    //    public async Task OnLoadCategoryModelCommandExequted(object p)
    //    {
    //        CategoryModelObsColl = new ObservableCollection<CategoryModel>();
    //        foreach(var item in await _CategoryRepository.Items.ToArrayAsync())
    //        {
    //            CategoryModelObsColl.Add(new CategoryModel(item));
    //        }
    //        SelectedCategoryModel = null; //костыль
    //    }

    //    #endregion


    //    #region Command AddNewCategoryCommand - Add new category

    //    /// <summary>Add new category</summary>
    //    private ICommand _AddNewCategoryCommand;

    //    /// <summary>Add new category</summary>
    //    public ICommand AddNewCategoryCommand => _AddNewCategoryCommand
    //        ??= new LambdaCommand(OnAddNewCategoryCommandExequted, CanAddNewCategoryCommandExequt);

    //    /// <summary>Checking the possibility of execution - Add new category</summary>
    //    public bool CanAddNewCategoryCommandExequt(object p) => true;

    //    /// <summary>Execution logic - Add new category</summary>
    //    public void OnAddNewCategoryCommandExequted(object p)
    //    {
    //        Category new_category = new();

    //        if (!_UserDialog.EditCategory(new_category)) return;

    //        _CategoryRepository.Add(new_category);

    //        CategoryModel categoryModel = new(new_category);

    //        CategoryModelObsColl.Add(categoryModel);

    //        SelectedCategoryModel = categoryModel;
    //    }

    //    #endregion


    //    #region Command ModifiCategoryCommand - Modifi CategorySearchWord

    //    /// <summary>Modifi CategorySearchWord</summary>
    //    private ICommand _ModifiCategoryCommand;

    //    /// <summary>Modifi CategorySearchWord</summary>
    //    public ICommand ModifiCategoryCommand => _ModifiCategoryCommand
    //        ??= new LambdaCommand(OnModifiCategoryCommandExequted, CanModifiCategoryCommandExequt);

    //    /// <summary>Checking the possibility of execution - Modifi CategorySearchWord</summary>
    //    public bool CanModifiCategoryCommandExequt(object p) => 
    //        p is CategoryModel categoryModel
    //        && SelectedCategoryModel is not null
    //        && categoryModel is not null;

    //    /// <summary>Execution logic - Modifi CategorySearchWord</summary>
    //    public void OnModifiCategoryCommandExequted(object p)
    //    {
    //        if (!(p is CategoryModel categoryModel)) return;

    //        var editing_Category = _CategoryRepository.Get(categoryModel.Id);

    //        if (!_UserDialog.EditCategory(editing_Category)) return;

    //        _CategoryRepository.Update(editing_Category);

    //        CategoryModelObsColl.Remove(categoryModel);

    //        categoryModel = new(editing_Category);
    //        CategoryModelObsColl.Add(categoryModel);

    //        SelectedCategoryModel = categoryModel;
    //    }

    //    #endregion


    //    #region Command RemoveCategoryCommand - Remove category

    //    /// <summary>Remove category</summary>
    //    private ICommand _RemoveCategoryCommand;

    //    /// <summary>Remove category</summary>
    //    public ICommand RemoveCategoryCommand => _RemoveCategoryCommand
    //        ??= new LambdaCommand(OnRemoveCategoryCommandExequted, CanRemoveCategoryCommandExequt);

    //    /// <summary>Checking the possibility of execution - Remove category</summary>
    //    public bool CanRemoveCategoryCommandExequt(object p) =>
    //        p is CategoryModel categoryModel
    //        && SelectedCategoryModel is not null
    //        && categoryModel is not null;

    //    /// <summary>Execution logic - Remove category</summary>
    //    public void OnRemoveCategoryCommandExequted(object p)
    //    {
    //        var category_to_remove = p ?? SelectedCategoryModel;

    //        if (!(category_to_remove is CategoryModel categoryModel)) return;

    //        if (!_UserDialog.ConfirmInformation($"Вы уверены, что хотите удалить категорию {categoryModel.Name}?", "Удаление категории")) return;

    //        _CategoryRepository.Remove(categoryModel.Id);

    //        CategoryModelObsColl.Remove(categoryModel);

    //        if (ReferenceEquals(SelectedCategoryModel, categoryModel)) SelectedCategoryModel = null;
    //    }

    //    #endregion




    //    #region Command AddNewCategorySearchWordCommand - Add new CategorySearchWord

    //    /// <summary>Add new CategorySearchWord</summary>
    //    private ICommand _AddNewCategorySearchWordCommand;

    //    /// <summary>Add new CategorySearchWord</summary>
    //    public ICommand AddNewCategorySearchWordCommand => _AddNewCategorySearchWordCommand
    //        ??= new LambdaCommand(OnAddNewCategorySearchWordCommandExequted, CanAddNewCategorySearchWordCommandExequt);

    //    /// <summary>Checking the possibility of execution - Add new CategorySearchWord</summary>
    //    public bool CanAddNewCategorySearchWordCommandExequt(object p) =>
    //        NewFieldToCategorySearchWord is not null
    //        && SelectedCategoryModel is not null
    //        && (SelectedCategoryModel.CategorySearchWordsObsColl is null || !SelectedCategoryModel.CategorySearchWordsObsColl.Select(cat => cat.Name).Contains(NewFieldToCategorySearchWord));

    //    /// <summary>Execution logic - Add new CategorySearchWord</summary>
    //    public void OnAddNewCategorySearchWordCommandExequted(object p)
    //    {
    //        CategorySearchWord new_categorySearchWord = new()
    //        {
    //            Name = NewFieldToCategorySearchWord,
    //            CategoryId = SelectedCategoryModel.Id,
    //            Category = _CategoryRepository.Get(SelectedCategoryModel.Id)
    //        };

    //        _CategorySearchWordRepository.Add(new_categorySearchWord);

    //        if (SelectedCategoryModel.CategorySearchWords is null) SelectedCategoryModel.CategorySearchWords = new List<CategorySearchWord>();
    //        SelectedCategoryModel.CategorySearchWords.Add(new_categorySearchWord);

    //        SelectedCategoryModel.CategorySearchWordsObsColl.Add(new_categorySearchWord);

    //        //UpdateCategoryModelSearchWordsView(SelectedCategoryModel);   возможно не поадобится
            
    //        SelectedCategorySearchWord = new_categorySearchWord;

    //        NewFieldToCategorySearchWord = null;
    //    }

    //    #endregion


    //    #region Command ModifiCategorySearchWordCommand - Modifi CategorySearchWord

    //    /// <summary>Modifi CategorySearchWord</summary>
    //    private ICommand _ModifiCategorySearchWordCommand;

    //    /// <summary>Modifi CategorySearchWord</summary>
    //    public ICommand ModifiCategorySearchWordCommand => _ModifiCategorySearchWordCommand
    //        ??= new LambdaCommand(OnModifiCategorySearchWordCommandExequted, CanModifiCategorySearchWordCommandExequt);

    //    /// <summary>Checking the possibility of execution - Modifi CategorySearchWord</summary>
    //    public bool CanModifiCategorySearchWordCommandExequt(object p) =>
    //        p is CategorySearchWord categorySearchWord
    //        && SelectedCategorySearchWord is not null
    //        && SelectedCategoryModel is not null
    //        && categorySearchWord is not null
    //        && EditFieldToCategorySearchWord is not null
    //        && !SelectedCategoryModel.CategorySearchWordsObsColl.Select(cat=>cat.Name).Contains(EditFieldToCategorySearchWord);

    //    /// <summary>Execution logic - Modifi CategorySearchWord</summary>
    //    public void OnModifiCategorySearchWordCommandExequted(object p)
    //    {
    //        var editing_categorySearchWord = p ?? SelectedCategorySearchWord;
    //        if (editing_categorySearchWord is not CategorySearchWord categorySearchWord) return;

    //        categorySearchWord.Name = EditFieldToCategorySearchWord;
    //        _CategorySearchWordRepository.Update(categorySearchWord);
            
    //        UpdateCategoryModelSearchWordsView(SelectedCategoryModel);
    //        SelectedCategorySearchWord = categorySearchWord;
            
    //        EditFieldToCategorySearchWord = null;
    //    }

    //    #endregion


    //    #region Command RemoveCategorySearchWordCommand - Remove CategorySearchWord

    //    /// <summary>Remove CategorySearchWord</summary>
    //    private ICommand _RemoveCategorySearchWordCommand;

    //    /// <summary>Remove CategorySearchWord</summary>
    //    public ICommand RemoveCategorySearchWordCommand => _RemoveCategorySearchWordCommand
    //        ??= new LambdaCommand(OnRemoveCategorySearchWordCommandExequted, CanRemoveCategorySearchWordCommandExequt);

    //    /// <summary>Checking the possibility of execution - Remove CategorySearchWord</summary>
    //    public bool CanRemoveCategorySearchWordCommandExequt(object p) =>
    //        p is CategorySearchWord categorySearchWord
    //        && SelectedCategorySearchWord is not null
    //        && categorySearchWord is not null;

    //    /// <summary>Execution logic - Remove CategorySearchWord</summary>
    //    public void OnRemoveCategorySearchWordCommandExequted(object p)
    //    {
    //        var categorySearchWord_to_remove = p ?? SelectedCategorySearchWord;

    //        if (!(categorySearchWord_to_remove is CategorySearchWord categorySearchWord)) return;

    //        if (!_UserDialog.ConfirmInformation($"Вы уверены, что хотите удалить категорию {categorySearchWord.Name}?", "Удаление категории")) return;

    //        _CategorySearchWordRepository.Remove(categorySearchWord.Id);

    //        SelectedCategoryModel.CategorySearchWordsObsColl.Remove(categorySearchWord);

    //        SelectedCategorySearchWord = null;

    //        //var vvv = SelectedCategoryModel.CategoryModelSearchWords.ToArray();


    //        //SelectedCategoryModel.CategoryModelSearchWords.Clear();  ////более-менее рабочий вариант

    //        //foreach (var item in vvv)
    //        //{
    //        //    if (item is null)
    //        //    {

    //        //        return;
    //        //    }
    //        //    SelectedCategoryModel.CategoryModelSearchWords.Add(item);
    //        //}

    //        SelectedCategorySearchWord = null;

    //        //if (ReferenceEquals(SelectedCategoryModelSearchWord, categorySearchWord)) SelectedCategoryModelSearchWord = null;

            

    //        //UpdateCategoryModelSearchWordsView(SelectedCategoryModel);
              

    //    }

    //    #endregion


    //    #endregion


    //    #region HeplfulMethods

    //    private void UpdateCategoryModelSearchWordsView(CategoryModel category)
    //    {
    //        SelectedCategoryModel = null;
    //        SelectedCategoryModel = category;
    //    }

    //    #endregion
    }
}
