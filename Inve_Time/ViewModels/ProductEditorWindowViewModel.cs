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
        private readonly IRepository<Category> _CategoryRepository;

        public ProductEditorWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }


        public ProductEditorWindowViewModel(ProductInfo productInfo, IRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;

            ProductName = productInfo.Name;
            ProductVendorCode = productInfo.VendorCode;
            ProductBarcode = productInfo.Barcode;
            ProductCost = productInfo.Cost;
            SelectedProductCategory = productInfo.Category;

            CategoryObsColl = new ObservableCollection<Category>(_CategoryRepository.Items.OrderBy(cat => cat.Name).ToArray());
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


        #region decimal? ProductCost && string ProductCostFromString

        private decimal? _ProductCost;
        /// <summary>ProductBase - Cost</summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ProductCost
        {
            get => _ProductCost;
            set 
            {
                if (Set(ref _ProductCost, value))
                {
                    ProductCostFromString = ProductCost.ToString();
                }
            }
        }

        

        private string _ProductCostFromString;
        /// <summary>ProductBase - Cost</summary>
        public string ProductCostFromString
        {
            get => _ProductCostFromString;
            set
            { 
                if(Set(ref _ProductCostFromString, ConvertToCost(value)))
                {
                    ProductCost = Convert.ToDecimal(ProductCostFromString);
                }
            } 
        }

        private string ConvertToCost(string line)
        {
            string new_line = null;

            bool plasedDot = false;
            int dotPosition = line.Length;

            for (int i = 0; i < line.Length && i <= dotPosition + 2; i++)
            {
                if (int.TryParse(line[i].ToString(), out int result)) new_line += result;

                if (!plasedDot && line[i].ToString() == "," || line[i].ToString() == ".")
                {
                    plasedDot = true;
                    dotPosition = i;
                    new_line += ",";
                }
            }
            return new_line;
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
