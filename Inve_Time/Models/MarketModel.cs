using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    public class MarketModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }



        public ObservableCollection<EmployeeModel> Staff { get; set; } = new ObservableCollection<EmployeeModel>();



        public ObservableCollection<InventoryEventModel> InventoryEvents { get; set; } = new ObservableCollection<InventoryEventModel>();
    }
}
