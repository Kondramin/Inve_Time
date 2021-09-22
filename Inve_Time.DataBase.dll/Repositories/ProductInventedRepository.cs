using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class ProductInventedRepository : DbRepository<ProductInvented>
    {

        public override IQueryable<ProductInvented> Items => base.Items
            .Include(item => item.InventarisationEvents)
            ;

        public ProductInventedRepository(InveTimeDB db) : base(db) { }
    }
}
