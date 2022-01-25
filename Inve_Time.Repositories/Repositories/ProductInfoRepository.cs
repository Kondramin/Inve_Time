using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories
{
    internal class ProductInfoRepository : DbRepository<ProductInfo>
    {


        public override IQueryable<ProductInfo> Items => base.Items
            .Include(item => item.Category)
            .Include(item => item.ProductInventeds)
            ;


        public ProductInfoRepository(InveTimeDB db) : base(db) { }

    }
}
