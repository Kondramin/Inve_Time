using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Inve_Time.ViewModels
{
    internal class ProductEditorWindowViewModel : ViewModel
    {
        private readonly IRepository<Category> _CategoryRepos;

        public ProductEditorWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }


        public ProductEditorWindowViewModel(ProductBase productBase, IRepository<Category> CategoryRepos)
        {
            _CategoryRepos = CategoryRepos;

            ProductName = productBase.Name;
            ProductVendorCode = productBase.VendorCode;
            ProductBarcode = productBase.Barcode;
            ProductCost = productBase.Cost;
            SelectedProductCategory = productBase.Category;
            CategoryObsColl = new ObservableCollection<Category>(_CategoryRepos.Items.OrderBy(cat => cat.Name).ToArray());
        }


        #region string ProductName

        private string _ProductName;
        /// <summary>ProductBase - Name</summary>
        public string ProductName
        {
            get => _ProductName;
            set => Set(ref _ProductName, value);
        }

        #endregion


        #region string ProductVendorCode

        private string _ProductVendorCode;
        /// <summary>ProductBase - VendorCode</summary>
        public string ProductVendorCode
        {
            get => _ProductVendorCode;
            set => Set(ref _ProductVendorCode, value);
        }

        #endregion


        #region string ProductBarcode

        private string _ProductBarcode;
        /// <summary>ProductBase - Barcode</summary>
        public string ProductBarcode
        {
            get => _ProductBarcode;
            set => Set(ref _ProductBarcode, value);
        }

        #endregion


        #region decimal? ProductCost

        private decimal? _ProductCost = null;
        /// <summary>ProductBase - Cost</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ProductCost
        {
            get => _ProductCost;
            set => Set(ref _ProductCost, value);
        }

        #endregion


        #region Category SelectedProductCategory

        private Category _SelectedProductCategory;
        /// <summary>ProductBase - Category</summary>
        public Category SelectedProductCategory
        {
            get => _SelectedProductCategory;
            set => Set(ref _SelectedProductCategory, value);
        }

        #endregion


        #region ObservableCollection<Category> CategoryObsColl

        private ObservableCollection<Category> _CategoryObsColl;
        /// <summary>Employee - Category</summary>
        public ObservableCollection<Category> CategoryObsColl
        {
            get => _CategoryObsColl;
            set => Set(ref _CategoryObsColl, value);
        }

        #endregion

                
    }
}
