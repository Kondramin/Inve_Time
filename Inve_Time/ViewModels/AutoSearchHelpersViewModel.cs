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
    class AutoSearchHelpersViewModel : ViewModel
    {
        private readonly IRepository<Category> _CategoryRepository;
        


        public AutoSearchHelpersViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        public AutoSearchHelpersViewModel(IRepository<Category> CategoryRepository) => _CategoryRepository = CategoryRepository;



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
            if (!(e.Item is Category category) || string.IsNullOrEmpty(FilterField)) return;

            if (category.Name == null || !category.Name.ToLower().Contains(FilterField.ToLower()))
                e.Accepted = false;
        }


        #endregion


        private CollectionViewSource _CategoryViewSource;


        public ICollectionView CategoryView => _CategoryViewSource?.View;


        #region SelectedCategory SelectedCategory

        private Category _SelectedCategory;
        /// <summary>SelectedCategory in ListBox</summary>
        public Category SelectedCategory
        {
            get => _SelectedCategory;
            set => Set(ref _SelectedCategory, value);
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


        #endregion
    }
}
