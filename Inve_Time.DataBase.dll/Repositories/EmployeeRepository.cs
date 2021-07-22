using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class EmployeeRepository : DbRepository<Employee>
    {


        public override IQueryable<Employee> Items => base.Items
            .Include(item => item.Position)
            .Include(Item => Item.CurrentInventarisations)
            ;


        public EmployeeRepository(InveTimeDB db) : base(db) { }

    }
}
