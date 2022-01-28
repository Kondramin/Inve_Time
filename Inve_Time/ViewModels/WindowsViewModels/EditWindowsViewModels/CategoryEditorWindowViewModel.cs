using Inve_Time.ViewModels.Base;
using System;

namespace Inve_Time.ViewModels.WindowsViewModels.EditWindowsViewModels
{
    internal class CategoryEditorWindowViewModel : ViewModel
    {

        public CategoryEditorWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        //public CategoryEditorWindowViewModel(/*Category category*/)
        //{
        //    CategoryId = category.Id;
        //    CategoryName = category.Name;
        //}


        //public int CategoryId { get; set; }


        //#region CategoryName

        //private string _CategoryName;
        ///// <summary>CategoryName to edit</summary>
        //public string CategoryName
        //{
        //    get => _CategoryName;
        //    set => Set(ref _CategoryName, value);
        //}

        //#endregion
    }
}
