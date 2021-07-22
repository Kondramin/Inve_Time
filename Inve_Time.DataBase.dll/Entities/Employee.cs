using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Employee : Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }



        public List<CurrentInventarisation> CurrentInventarisations { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
    }
}
