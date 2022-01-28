using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    public class ProductInventedModel
    {
        public int Id { get; set; }
        public int AmountData { get; set; }
        public int AmountFact { get; set; }



        /// <summary>Result = AmountData - AmountFact</summary>
        /// <returns>Result</returns>
        public int AmountResult()
        {
            return AmountData - AmountFact;
        } 
        public bool Re_Grading { get; set; }



        public ProductModel ProductInfo { get; set; }



        public ObservableCollection<InventoryEventModel> InventoryEvents { get; set; } = new ObservableCollection<InventoryEventModel>();
    }
}
