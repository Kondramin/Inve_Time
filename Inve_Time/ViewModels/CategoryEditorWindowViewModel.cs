using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    internal class CategoryEditorWindowViewModel : ViewModel
    {
        private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;


        public CategoryEditorWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        public CategoryEditorWindowViewModel(Category category, IRepository<CategorySearchWord> CategorySearchWordRepository)
        {
            CategoryId = category.Id;

            CategorySearchWordsCollection = new ObservableCollection<CategorySearchWord>(category.CategorySearchWords);

            
            _CategorySearchWordRepository = CategorySearchWordRepository;
        }



        public int CategoryId { get; set; }


        #region CategoryName

        private string _CategoryName;
        /// <summary>CategoryName to edit</summary>
        public string CategoryName
        {
            get => _CategoryName;
            set => Set(ref _CategoryName, value);
        }

        #endregion


        #region ObservableCollection<CategorySearchWord> CategorySearchWordsCollection

        private ObservableCollection<CategorySearchWord> _CategorySearchWordsCollection;
        /// <summary>Search word of category</summary>
        public ObservableCollection<CategorySearchWord> CategorySearchWordsCollection
        {
            get => _CategorySearchWordsCollection;
            set => Set(ref _CategorySearchWordsCollection, value);
        }

        #endregion


        #region SelectedCategorySearchWord

        private CategorySearchWord _SelectedCategorySearchWord;
        /// <summary>Selected "hot word"</summary>
        public CategorySearchWord SelectedCategorySearchWord
        {
            get => _SelectedCategorySearchWord;
            set => Set(ref _SelectedCategorySearchWord, value);
        }

        #endregion


        #region NewOrSelectedCategorySearchWord

        private string _NewOrSelectedCategorySearchWord;
        /// <summary>NewOrSelected "hot word"</summary>
        public string NewOrSelectedCategorySearchWord
        {
            get => _NewOrSelectedCategorySearchWord;
            set => Set(ref _NewOrSelectedCategorySearchWord, value);
        }

        #endregion




        #region Command AddCategorySearchWordCommand - Add category search word

        /// <summary>Add category search word</summary>
        private ICommand _AddCategorySearchWordCommand;

        /// <summary>Add category search word</summary>
        public ICommand AddCategorySearchWordCommand => _AddCategorySearchWordCommand
            ??= new LambdaCommand(OnAddCategorySearchWordCommandExequted, CanAddCategorySearchWordCommandExequt);

        /// <summary>Checking the possibility of execution - Add category search word</summary>
        public bool CanAddCategorySearchWordCommandExequt(object p) => NewOrSelectedCategorySearchWord != SelectedCategorySearchWord.Name;

        /// <summary>Execution logic - Add category search word</summary>
        public void OnAddCategorySearchWordCommandExequted(object p)
        {
            var new_categorySearchWord = new CategorySearchWord()
            {
                Name = NewOrSelectedCategorySearchWord,
                CategoryId = CategoryId
            };

            _CategorySearchWordRepository.Add(new_categorySearchWord);
            CategorySearchWordsCollection.Add(new_categorySearchWord);
        }

        #endregion


        #region Command ModifiCategorySearchWordCommand - Modifi category search word

        /// <summary>Modifi category search word</summary>
        private ICommand _ModifiCategorySearchWordCommand;

        /// <summary>Modifi category search word</summary>
        public ICommand ModifiCategorySearchWordCommand => _ModifiCategorySearchWordCommand
            ??= new LambdaCommand(OnModifiCategorySearchWordCommandExequted, CanModifiCategorySearchWordCommandExequt);

        /// <summary>Checking the possibility of execution - Modifi category search word</summary>
        public bool CanModifiCategorySearchWordCommandExequt(object p) => NewOrSelectedCategorySearchWord == SelectedCategorySearchWord.Name;

        /// <summary>Execution logic - Modifi category search word</summary>
        public void OnModifiCategorySearchWordCommandExequted(object p)
        {

        }

        #endregion


        #region Command RemoveCategorySearchWordCommand - Remove category search word

        /// <summary>Remove category search word</summary>
        private ICommand _RemoveCategorySearchWordCommand;
        

        /// <summary>Remove category search word</summary>
        public ICommand RemoveCategorySearchWordCommand => _RemoveCategorySearchWordCommand
            ??= new LambdaCommand(OnRemoveCategorySearchWordCommandExequted, CanRemoveCategorySearchWordCommandExequt);

        /// <summary>Checking the possibility of execution - Remove category search word</summary>
        public bool CanRemoveCategorySearchWordCommandExequt(object p) => (p is CategorySearchWord) || (SelectedCategorySearchWord is not null);

        /// <summary>Execution logic - Remove category search word</summary>
        public void OnRemoveCategorySearchWordCommandExequted(object p)
        {

        }

        #endregion


    }
}
