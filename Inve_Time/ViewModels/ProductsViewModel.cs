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
    internal class ProductsViewModel : ViewModel
    {
        private readonly IRepository<ProductInfo> _ProductInfoRepos;
        private readonly IUserDialog _UserDialog;

        public ProductsViewModel(
            IRepository<ProductInfo> ProductInfoRepos,
            IUserDialog UserDialog
            )
        {
            _ProductInfoRepos = ProductInfoRepos;
            _UserDialog = UserDialog;
        }

        public ProductsViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }


        #region ObservableCollection<ProductBase> ProductsObsColl - ObservableCollection of products 

        private ObservableCollection<ProductInfo> _ProductsObsColl;
        /// <summary>ProductsObsColl - ObservableCollection of products</summary>
        public ObservableCollection<ProductInfo> ProductsObsColl
        {
            get => _ProductsObsColl;
            set
            {
                if (Set(ref _ProductsObsColl, value))
                {
                    _ProductsViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(ProductInfo.Category.Name), ListSortDirection.Ascending)
                        }

                    };

                    _ProductsViewSource.Filter += OnAnyFilter;
                    _ProductsViewSource.Filter += OnProductNameFilter;
                    _ProductsViewSource.Filter += OnVendorCodeFilter;
                    _ProductsViewSource.Filter += OnBarcodeFilter;
                    _ProductsViewSource.Filter += OnLowCostFilter;
                    _ProductsViewSource.Filter += OnHightCostFilter;


                    _ProductsViewSource.View.Refresh();

                    OnPropertyChanged(nameof(ProductsView));

                }
            }
        }

        #endregion


        /// <summary>CollectoinViewSource of products</summary>
        private CollectionViewSource _ProductsViewSource;


        /// <summary>ICollection of EmpBaseInfo. Using to show in DataGrid</summary>
        public ICollectionView ProductsView => _ProductsViewSource?.View;


        #region ProductBase SelectedProduct

        private ProductInfo _SelectedProduct;
        /// <summary>SelectedProduct in DataGrid</summary>
        public ProductInfo SelectedProduct
        {
            get => _SelectedProduct;
            set => Set(ref _SelectedProduct, value);
        }

        #endregion



        #region About Filters


        private void OnAnyFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not ProductInfo productBase || string.IsNullOrEmpty(FilterAnyWord)) return;

            if (!ConvetnToAny(productBase).ToLower().Contains(FilterAnyWord.ToLower()))
                e.Accepted = false;
        }

        private void OnProductNameFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not ProductInfo productBase || string.IsNullOrEmpty(FilterProductNameWord)) return;

            if (productBase.Name == null || !productBase.Name.ToLower().Contains(FilterProductNameWord.ToLower()))
                e.Accepted = false;
        }

        private void OnVendorCodeFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not ProductInfo productBase || string.IsNullOrEmpty(FilterVendorCodeWord)) return;

            if (productBase.VendorCode == null || !productBase.VendorCode.Contains(FilterVendorCodeWord))
                e.Accepted = false;
        }

        private void OnBarcodeFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not ProductInfo productBase || string.IsNullOrEmpty(FilterBarcodeWord)) return;

            if (productBase.Barcode == null || !productBase.Barcode.ToLower().Contains(FilterBarcodeWord.ToLower()))
            {
                e.Accepted = false;
            }
        }

        private void OnLowCostFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not ProductInfo productBase || string.IsNullOrEmpty(FilterLowCostWord)) return;

            if (productBase.Cost == null || productBase.Cost < Convert.ToDecimal(FilterLowCostWord))
            {
                e.Accepted = false;
            }
        }

        private void OnHightCostFilter(object sender, FilterEventArgs e)
        {
            if (e.Item is not ProductInfo productBase || string.IsNullOrEmpty(FilterHightCostWord)) return;

            if (productBase.Cost == null || productBase.Cost > Convert.ToDecimal(FilterHightCostWord))
            {
                e.Accepted = false;
            }
        }


        #region Filter Fields


        #region string ProductsView FilterAny 

        private string _FilterAnyWord;
        /// <summary>ProductsView FilterAny - searching word</summary>
        public string FilterAnyWord
        {
            get => _FilterAnyWord;
            set
            {
                if (Set(ref _FilterAnyWord, value))
                    _ProductsViewSource.View.Refresh();
            }
        }

        #endregion

        #region string ProductsView FilterProductName 

        private string _FilterProductNameWord;
        /// <summary>ProductsView FilterProductName - searching word</summary>
        public string FilterProductNameWord
        {
            get => _FilterProductNameWord;
            set
            {
                if (Set(ref _FilterProductNameWord, value))
                    _ProductsViewSource.View.Refresh();
            }
        }

        #endregion

        #region string ProductsView FilterVendorCode 

        private string _FilterVendorCodeWord;
        /// <summary>ProductsView FilterVendorCode - searching word</summary>
        public string FilterVendorCodeWord
        {
            get => _FilterVendorCodeWord;
            set
            {
                if (Set(ref _FilterVendorCodeWord, value))
                    _ProductsViewSource.View.Refresh();
            }
        }

        #endregion

        #region string ProductsView FilterBarcode 

        private string _FilterBarcodeWord;
        /// <summary>ProductsView FilterBarcode - searching word</summary>
        public string FilterBarcodeWord
        {
            get => _FilterBarcodeWord;
            set
            {
                if (Set(ref _FilterBarcodeWord, value))
                    _ProductsViewSource.View.Refresh();
            }
        }

        #endregion

        #region string ProductsView FilterLowCost 

        private string _FilterLowCostWord;
        /// <summary>ProductsView FilterLowCost - searching string</summary>
        public string FilterLowCostWord
        {
            get => _FilterLowCostWord;
            set
            {
                if (Set(ref _FilterLowCostWord, ConvertToCost(value)))
                    _ProductsViewSource.View.Refresh();
            }
        }

        #endregion

        #region string ProductsView FilterHightCost 

        private string _FilterHightCostWord;
        /// <summary>ProductsView FilterHightCost - searching string</summary>
        public string FilterHightCostWord
        {
            get => _FilterHightCostWord;
            set
            {
                if (Set(ref _FilterHightCostWord, ConvertToCost(value)))
                    _ProductsViewSource.View.Refresh();
            }
        }

        #endregion


        #endregion


        private string ConvetnToAny(ProductInfo productBase)
        {
            return productBase.VendorCode ?? "" + productBase.Barcode ?? "" + productBase.Name ?? "";
        }

        private string ConvertToCost(string line)
        {
            string new_line = null;

            bool plasedDot = false;
            int dotPosition = line.Length;

            for(int i = 0; i < line.Length && i <= dotPosition+2; i++)
            {
                if (int.TryParse(line[i].ToString(), out int result)) new_line += result;

                if(!plasedDot && line[i].ToString() == "," || line[i].ToString() == ".")
                {
                    plasedDot = true;
                    dotPosition = i;
                    new_line += ",";
                }
            }
            return new_line;
        }
        
        
        #endregion



        #region Commands



        #region Command LoadProductBaseCommand - Load Products from database

        /// <summary>Load Products from database</summary>
        private ICommand _LoadProductBaseCommand;

        /// <summary>Load Products from database</summary>
        public ICommand LoadProductBaseCommand => _LoadProductBaseCommand
            ??= new LambdaCommandAsync(OnLoadProductBaseCommandExequted);

        /// <summary>Execution logic - Load Products from database</summary>
        public async Task OnLoadProductBaseCommandExequted(object p)
        {
            ProductsObsColl = new ObservableCollection<ProductInfo>(await _ProductInfoRepos.Items
                .OrderBy(p => p.Category.Name)
                .ThenBy(p => p.Name)
                .ToArrayAsync());
        }

        #endregion


        #region Command CleanFilterFieldsCommand - Clean filter fields

        /// <summary>Clean filter fields</summary>
        private ICommand _CleanFilterFieldsCommand;

        /// <summary>Clean filter fields</summary>
        public ICommand CleanFilterFieldsCommand => _CleanFilterFieldsCommand
            ??= new LambdaCommand(OnCleanFilterFieldsCommandExequted);

        /// <summary>Execution logic - Clean filter fields</summary>
        public void OnCleanFilterFieldsCommandExequted(object p)
        {
            FilterAnyWord = null;
            FilterProductNameWord = null;
            FilterVendorCodeWord = null;
            FilterBarcodeWord = null;
            FilterLowCostWord = null;
            FilterHightCostWord = null;
        }

        #endregion


        #region Command AddNewProductCommand - Add new product

        /// <summary>Add new product</summary>
        private ICommand _AddNewProductCommand;

        /// <summary>Add new product</summary>
        public ICommand AddNewProductCommand => _AddNewProductCommand
            ??= new LambdaCommand(OnAddNewProductCommandExequted, CanAddNewProductCommandExequt);

        /// <summary>Checking the possibility of execution - Add new product</summary>
        public bool CanAddNewProductCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 3;

        /// <summary>Execution logic - Add new product</summary>
        public void OnAddNewProductCommandExequted(object p)
        {
            var new_product = new ProductInfo();

            if (!_UserDialog.EditProduct(new_product)) return;

            ProductsObsColl.Add(_ProductInfoRepos.Add(new_product));

            SelectedProduct = new_product;
        }

        #endregion


        #region Command ModifiProductCommand - Modifi product

        /// <summary>Modifi product</summary>
        private ICommand _ModifiProductCommand;

        /// <summary>Modifi product</summary>
        public ICommand ModifiProductCommand => _ModifiProductCommand
            ??= new LambdaCommand(OnModifiProductCommandExequted, CanModifiProductCommandExequt);

        /// <summary>Checking the possibility of execution - Modifi product</summary>
        public bool CanModifiProductCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 5;

        /// <summary>Execution logic - Modifi product</summary>
        public void OnModifiProductCommandExequted(object p)
        {
            var product_toModifi = p ?? SelectedProduct;

            if (product_toModifi is not ProductInfo productBase) return;

            if (!_UserDialog.EditProduct(productBase)) return;

            _ProductInfoRepos.Update(productBase);

            ProductsObsColl.Remove(productBase);
            ProductsObsColl.Add(productBase);

            SelectedProduct = productBase;
        }

        #endregion


        #region Command RemoveProductCommand - Remove product

        /// <summary>Remove product</summary>
        private ICommand _RemoveProductCommand;

        /// <summary>Remove product</summary>
        public ICommand RemoveProductCommand => _RemoveProductCommand
            ??= new LambdaCommand(OnRemoveProductCommandExequted, CanRemoveProductCommandExequt);

        /// <summary>Checking the possibility of execution - Remove product</summary>
        public bool CanRemoveProductCommandExequt(object p) => MainWindowViewModel.AutorisatedEmployee.Position.AccessLevel > 7;

        /// <summary>Execution logic - Remove product</summary>
        public void OnRemoveProductCommandExequted(object p)
        {
            var emp_to_remove = p ?? SelectedProduct;

            if (emp_to_remove is not ProductInfo productBase) return;

            if (!_UserDialog.ConfirmInformation($"Вы уверены, что хотите удалить товар {productBase.Name}?", "Удаление товара")) return;

            _ProductInfoRepos.Remove(productBase.Id);

            ProductsObsColl.Remove(productBase);
            if (ReferenceEquals(SelectedProduct, productBase)) SelectedProduct = null;
        }

        #endregion



        #endregion

    }
}
