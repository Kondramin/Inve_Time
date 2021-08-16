using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities.Base;
using Inve_Time.Interfaces.dll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inve_Time.DataBase.dll.Repositories.Base
{
    internal class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly InveTimeDB _db;
        private readonly DbSet<T> _Set;


        public bool AutoSaveChanges { get; set; } = true;


        public DbRepository(InveTimeDB db)
        {
            _db = db;
            _Set = db.Set<T>();
        }



        public virtual IQueryable<T> Items => _Set;

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges) _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges) await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken Cancel = default) => await Items
            .SingleOrDefaultAsync(item => item.Id == id, Cancel)
            .ConfigureAwait(false);


        public void Remove(int id)
        {
            var item = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

            _db.Remove(item);

            if (AutoSaveChanges) _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            var item = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };

            _db.Remove(item);

            if (AutoSaveChanges) await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            //var it = _Set.Local.FirstOrDefault(i => i.Id == item.Id) ?? item;
            //TODO: The instance of entity type 'Employee' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.

            _db.Entry(item).State = EntityState.Modified;
            

            if (AutoSaveChanges) _db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges) await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
