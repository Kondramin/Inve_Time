using Inve_Time.Entities.Base;
using System;
using System.Collections.Generic;

namespace Inve_Time.Entities.Entities
{
    public class InventoryEvent : Entity
    {
        public DateTime DateOfEvent { get; set; }
        public bool OpenToModifi { get; set; } = true;



        public int? EmployeeId { get; set; }
        public Employee ResponsibleEmployee { get; set; }



        public ICollection<ProductInvented> ProductInventeds { get; set; }
    }
}
