using Inve_Time.Models.Base;
using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    public class MarketModel : EntityModel
    {
        public string Name { get; set; }
        public string Address { get; set; }



        public ObservableCollection<EmployeeModel> Staff { get; set; } = new ObservableCollection<EmployeeModel>();



        public ObservableCollection<InventoryEventModel> InventoryEvents { get; set; } = new ObservableCollection<InventoryEventModel>();
    }
}
