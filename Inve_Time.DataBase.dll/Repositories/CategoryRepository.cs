using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class CategoryRepository : DbRepository<Category>
    {

        public override IQueryable<Category> Items => base.Items
            .Include(item => item.Products)
            .Include(item => item.CategorySearchWords)
            ;

        public CategoryRepository(InveTimeDB db) : base(db) { }
    }
}
