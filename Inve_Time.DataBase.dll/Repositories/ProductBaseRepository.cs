using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class ProductBaseRepository : DbRepository<ProductBase>
    {


        public override IQueryable<ProductBase> Items => base.Items
            .Include(item => item.Category)
            .Include(item => item.ProductInventeds)
            ;


        public ProductBaseRepository(InveTimeDB db) : base(db) { }

    }
}
