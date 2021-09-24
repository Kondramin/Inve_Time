using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    internal class CategoryEditorWindowViewModel : ViewModel
    {
        public CategoryEditorWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        public CategoryEditorWindowViewModel(Category category)
        {
            EditingCategory = category;
        }

        #region EditingCategory

        private Category _EditingCategory;
        /// <summary>Category to edit</summary>
        public Category EditingCategory
        {
            get => _EditingCategory;
            set => Set(ref _EditingCategory, value);
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
        public bool CanAddCategorySearchWordCommandExequt(object p) => true;

        /// <summary>Execution logic - Add category search word</summary>
        public void OnAddCategorySearchWordCommandExequted(object p)
        {

        }

        #endregion


        #region Command ModifiCategorySearchWordCommand - Modifi category search word

        /// <summary>Modifi category search word</summary>
        private ICommand _ModifiCategorySearchWordCommand;

        /// <summary>Modifi category search word</summary>
        public ICommand ModifiCategorySearchWordCommand => _ModifiCategorySearchWordCommand
            ??= new LambdaCommand(OnModifiCategorySearchWordCommandExequted, CanModifiCategorySearchWordCommandExequt);

        /// <summary>Checking the possibility of execution - Modifi category search word</summary>
        public bool CanModifiCategorySearchWordCommandExequt(object p) => true;

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
        public bool CanRemoveCategorySearchWordCommandExequt(object p) => true;

        /// <summary>Execution logic - Remove category search word</summary>
        public void OnRemoveCategorySearchWordCommandExequted(object p)
        {

        }

        #endregion


    }
}
