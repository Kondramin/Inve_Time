using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CategoryId = category.Id;
            CategoryName = category.Name;
            CategorySearchWordCollection = new(category.CategorySearchWords.ToArray());
        }

        public int CategoryId { get; set; }

        #region string CategoryName

        private string _CategoryName;
        /// <summary>Category - Name</summary>
        public string CategoryName
        {
            get => _CategoryName;
            set => Set(ref _CategoryName, value);
        }

        #endregion

        #region CategorySearchWord CategorySearchWord

        private CategorySearchWord _CategorySearchWord;
        /// <summary>Category - Name</summary>
        public CategorySearchWord CategorySearchWord
        {
            get => _CategorySearchWord;
            set => Set(ref _CategorySearchWord, value);
        }

        #endregion

        #region ObservableCollection<CategorySearchWord> CategorySearchWordCollection

        private ObservableCollection<CategorySearchWord> _CategorySearchWordCollection;
        /// <summary>Category - CategorySearchWordWords</summary>
        public ObservableCollection<CategorySearchWord> CategorySearchWordCollection
        {
            get => _CategorySearchWordCollection;
            set => Set(ref _CategorySearchWordCollection, value);
        }

        #endregion
    }
}
