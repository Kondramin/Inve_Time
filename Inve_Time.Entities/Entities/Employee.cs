using Inve_Time.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.Entities.Entities
{
    public class Employee : PersonEntity
    {
        public string Login { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }



        public int? PositionId { get; set; }
        public Position Position { get; set; }



        public int? PasswodrId { get; set; }
        public Password Password { get; set; }



        public ICollection<InventoryEvent> InventoryEvents { get; set; }

    }
}
