using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    public class PositionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }



        public ObservableCollection<EmployeeModel> Employees { get; set; } = new ObservableCollection<EmployeeModel>();
    }
}
