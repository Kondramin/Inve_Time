using Inve_Time.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.Entities.Entities
{
    public class Market : NamedEntity
    {
        public string Address { get; set; }



        public ICollection<Employee> Staff { get; set; }



        public ICollection<InventoryEvent> InventoryEvents { get; set; }
    }
}
