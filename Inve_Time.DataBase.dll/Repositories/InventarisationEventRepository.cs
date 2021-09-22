using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class InventarisationEventRepository : DbRepository<InventarisationEvent>
    {

        public override IQueryable<InventarisationEvent> Items => base.Items
            .Include(item => item.ResponsibleForEvent)
            .Include(item => item.ProductInventeds)
            ;

        public InventarisationEventRepository(InveTimeDB db) : base(db) { }
    }
}