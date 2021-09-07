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
        private readonly InveTimeDB _db;
        private readonly DbSet<Employee> _Set;

        public override IQueryable<Employee> Items => base.Items
            .Include(item => item.Position)
            .Include(Item => Item.CurrentInventarisations)
            ;


        public override void Remove(int id)
        {
            var item = _Set.Include(item => item.Password).FirstOrDefault(i => i.Id == id) ?? new Employee { Id = id };

            _db.Remove(item);

            if (AutoSaveChanges) _db.SaveChanges();
        }


        public override async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            var item = _Set.Include(item => item.Password).FirstOrDefault(i => i.Id == id) ?? new Employee { Id = id };

            _db.Remove(item);

            if (AutoSaveChanges) await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public EmployeeRepository(InveTimeDB db) : base(db)
        {
            _db = db;
            _Set = db.Set<Employee>();
        }

    }
}
