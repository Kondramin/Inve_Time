using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class EmployeeRepository : DbRepository<Employee>
    {


        public override IQueryable<Employee> Items => base.Items
            .Include(item => item.Position)
            .Include(Item => Item.CurrentInventarisations)
            ;


        public override void Remove(int id)
        {
            //var item = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };
            
            //base.Remove(id);
        }


        public override Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            return base.RemoveAsync(id, Cancel);
        }

        public EmployeeRepository(InveTimeDB db) : base(db) { }

    }
}
