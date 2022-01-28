using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories.Repositories
{
    internal class CategoryRepository : DbRepository<Category>
    {
        public CategoryRepository(InveTimeDB db) : base(db) { }



        public override IQueryable<Category> Items => base.Items
            .Include(item => item.Products)
            .Include(item => item.CategorySearchWords)
            ;

    }
}
