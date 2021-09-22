using Inve_Time.DataBase.dll.Entities.Base;
using System;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class InventarisationEvent : Entity
    {
        public DateTime DateOfEvent { get; set; }


        public int? EmployeeId { get; set; }
        public Employee ResponsibleForEvent { get; set; }
        public ICollection<ProductInvented> ProductInventeds { get; set; }
    }
}
