using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    public class EmployeeModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }



        public PositionModel Position { get; set; }



        public MarketModel Market { get; set; }



        public ObservableCollection<InventoryEventModel> InventoryEvents { get; set; }


        /// <summary>Helpful property. Return SecondName, Name, Patronymic in one field as FIO</summary>
        public string Fio { get => SecondName + " " + Name + " " + Patronymic; }



        /// <summary>Helpful property. Using in filters</summary>
        public string Any { get => (SecondName ?? "") + (Name ?? "") + (Patronymic ?? "") + (Phone ?? "") + (Email ?? "") + (Position.Name ?? ""); }
    }
}
