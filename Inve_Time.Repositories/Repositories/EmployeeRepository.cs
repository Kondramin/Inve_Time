using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories.Repositories
{
    internal class EmployeeRepository : DbRepository<Employee>
    {
        private readonly InveTimeDB _db;
        private readonly DbSet<Employee> _Set;


        public EmployeeRepository(InveTimeDB db) : base(db)
        {
            _db = db;
            _Set = db.Set<Employee>();
        }



        public override IQueryable<Employee> Items => base.Items
            .Include(item => item.Position)
            .Include(item => item.Market)
            .Include(item => item.InventoryEvents)
            ;




        //TODO: Пока не знаю, пригодится ли с учётом переделки. Если не понадобится, то переделать конструктор.
        //public override void Remove(int id)
        //{
        //    var item = _Set.Include(item => item.Password).FirstOrDefault(i => i.Id == id) ?? new Employee { Id = id };

        //    _db.Remove(item);

        //    if (AutoSaveChanges) _db.SaveChanges();
        //}


        //public override async Task RemoveAsync(int id, CancellationToken Cancel = default)
        //{
        //    var item = _Set.Include(item => item.Password).FirstOrDefault(i => i.Id == id) ?? new Employee { Id = id };

        //    _db.Remove(item);

        //    if (AutoSaveChanges) await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        //}

        

    }
}
