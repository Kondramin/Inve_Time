using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories.Repositories
{
    internal class InventoryEventRepository : DbRepository<InventoryEvent>
    {
        public InventoryEventRepository(InveTimeDB db) : base(db) { }



        public override IQueryable<InventoryEvent> Items => base.Items
            .Include(item => item.ResponsibleEmployee)
            .Include(item => item.Market)
            .Include(item => item.ProductInventeds)
            ;

    }
}