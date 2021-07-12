using Inve_Time.DataBase.dll.Entities.Base;
using System;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class DateOfInventarisation : Entity
    {
        public DateTime InventarisationDate { get; set; }



        public int? EmployeeId { get; set; }
        public Employee ResponsibleForEvent { get; set; }
        public List<Product> Products { get; set; }
    }
}
