using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories
{
    internal class ProductInventedRepository : DbRepository<ProductInvented>
    {
        public ProductInventedRepository(InveTimeDB db) : base(db) { }



        public override IQueryable<ProductInvented> Items => base.Items
            .Include(item => item.ProductInfo)
            .Include(item => item.InventoryEvents)
            ;

    }
}
