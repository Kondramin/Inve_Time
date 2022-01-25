using Inve_Time.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.Entities.Entities
{
    public class Position : NamedEntity
    {
        public int AccessLevel { get; set; }



        public ICollection<Employee> Employees { get; set; }
    }
}
