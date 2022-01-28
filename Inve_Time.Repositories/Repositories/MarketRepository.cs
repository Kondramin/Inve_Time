using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories.Repositories
{
    internal class MarketRepository : DbRepository<Market>
    {
        public MarketRepository(InveTimeDB db) : base(db) { }



        public override IQueryable<Market> Items => base.Items
            .Include(item => item.Staff)
            .Include(item => item.InventoryEvents)
            ;

    }
}
