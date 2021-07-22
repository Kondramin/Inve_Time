using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class ProductRepository : DbRepository<Product>
    {


        public override IQueryable<Product> Items => base.Items
            .Include(item => item.Category)
            .Include(item => item.CurrentInventarisations)
            ;


        public ProductRepository(InveTimeDB db) : base(db) { }

    }
}
