using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories.Repositories
{
    internal class ProductRepository : DbRepository<Product>
    {
        public ProductRepository(InveTimeDB db) : base(db) { }



        public override IQueryable<Product> Items => base.Items
            .Include(item => item.Category)
            ;

    }
}
