using Inve_Time.Models.Base;
using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    public class PositionModel : EntityModel
    {
        public string Name { get; set; }
        public int AccessLevel { get; set; }



        public ObservableCollection<EmployeeModel> Employees { get; set; } = new ObservableCollection<EmployeeModel>();
    }
}
