using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Position : NamedEntity
    {
        public int AccessLevel { get; set; }


        public ICollection<Employee> Employees { get; set; }
    }
}
