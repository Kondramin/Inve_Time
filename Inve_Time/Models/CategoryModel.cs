using Inve_Time.DataBase.dll.Entities;
using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    class CategoryModel : Category
    {
        public CategoryModel()
        {
            ProductsObsColl = (Products is null) ? new ObservableCollection<ProductInfo>() : new ObservableCollection<ProductInfo>(Products);
            CategorySearchWordsObsColl = (CategorySearchWords is null) ? new ObservableCollection<CategorySearchWord>() : new ObservableCollection<CategorySearchWord>(CategorySearchWords);
        }

        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Products = category.Products;
            CategorySearchWords = category.CategorySearchWords;

            ProductsObsColl = (Products is null) ? new ObservableCollection<ProductInfo>() : new ObservableCollection<ProductInfo>(Products);
            CategorySearchWordsObsColl = (CategorySearchWords is null) ? new ObservableCollection<CategorySearchWord>() : new ObservableCollection<CategorySearchWord>(CategorySearchWords);
        }
        public ObservableCollection<ProductInfo> ProductsObsColl { get; set; }

        public ObservableCollection<CategorySearchWord> CategorySearchWordsObsColl { get; set; }
    }
}
