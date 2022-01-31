using Inve_Time.Entities.Interface;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inve_Time.Interfaces.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {


        /// <summary>Return all entities of selected type</summary>
        IQueryable<T> Items { get; }

        /// <summary>
        /// This property using to safe data in database. When you need add/update/remove many entities at a time, 
        /// you need set this value to false. But don't forget to save data manually.
        /// </summary>
        bool AutoSaveChanges { get; set; }


        /// <summary>
        /// Return current entity
        /// </summary>
        /// <param name="id">Id current entity</param>
        /// <returns>Current entity</returns>
        T Get(int id);


        /// <summary>
        /// Return current entity async
        /// </summary>
        /// <param name="id">Id current entity</param>
        /// <returns>Current entity</returns>
        Task<T> GetAsync(int id, CancellationToken Cancel = default);


        /// <summary>
        /// Add entity in database
        /// </summary>
        /// <param name="item">New entity</param>
        /// <returns>Added(new) entity</returns>
        T Add(T item);


        /// <summary>
        /// Add entity in database async
        /// </summary>
        /// <param name="item">New entity</param>
        /// <param name="Cancel"></param>
        /// <returns>Added(new) entity</returns>
        Task<T> AddAsync(T item, CancellationToken Cancel = default);


        /// <summary>
        /// Update entity in database
        /// </summary>
        /// <param name="item">Updated entity</param>
        void Update(T item);


        /// <summary>
        /// Update entity in database async
        /// </summary>
        /// <param name="item">Updated entity</param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        Task UpdateAsync(T item, CancellationToken Cancel = default);


        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="id">Deleted entity</param>
        void Remove(int id);


        /// <summary>
        /// Delete entity from database async
        /// </summary>
        /// <param name="id">Deleted entity</param>
        /// <param name="Cancel"></param>
        /// <returns></returns>
        Task RemoveAsync(int id, CancellationToken Cancel = default);
    }
}
