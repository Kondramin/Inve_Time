using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class CategorySearchWordRepository : DbRepository<CategorySearchWord>
    {

        public override IQueryable<CategorySearchWord> Items => base.Items
            .Include(item => item.Category)
            ;

        public CategorySearchWordRepository(InveTimeDB db) : base(db) { }
    }
}
