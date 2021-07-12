using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class DateOfInventarisationRepository : DbRepository<DateOfInventarisation>
    {

        public override IQueryable<DateOfInventarisation> Items => base.Items
            .Include(item => item.ResponsibleForEvent)
            .Include(item => item.Products)
            ;

        public DateOfInventarisationRepository(InveTimeDB db) : base(db) { }
    }
}
