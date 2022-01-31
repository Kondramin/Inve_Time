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



        public string PositionName { get; set; }



        public string MarketName { get; set; }



        /// <summary>Helpful property. Return SecondName, Name, Patronymic in one field as FIO</summary>
        public string Fio { get => SecondName + " " + Name + " " + Patronymic; }



        /// <summary>Helpful property. Using in filters</summary>//TODO: Проверить необходимость
        public string Any { get => (SecondName ?? "") + (Name ?? "") + (Patronymic ?? "") + (Phone ?? "") + (Email ?? "") + (PositionName ?? ""); }
    }
}
