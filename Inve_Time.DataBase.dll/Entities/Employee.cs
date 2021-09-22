using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Employee : Person
    {
        public string Login { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public int? PositionId { get; set; }
        public Position Position { get; set; }


        public int? PasswodrId { get; set; }
        public Password Password { get; set; }


        public ICollection<InventarisationEvent> InventarisationEvents { get; set; }

    }
}
