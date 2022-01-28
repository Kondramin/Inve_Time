using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    public class CategoryModel
    {   
        public int Id { get; set; }
        public string Name { get; set; }



        public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();
        public ObservableCollection<CategorySearchWordModel> CategorySearchWords { get; set; } = new ObservableCollection<CategorySearchWordModel>();

    }
}
