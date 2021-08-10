using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.DataBase.dll.Repositories
{
    internal class HelpCategorySearchRepository : DbRepository<HelpCategorySearch>
    {

        public override IQueryable<HelpCategorySearch> Items => base.Items
            .Include(item => item.Category)
            ;

        public HelpCategorySearchRepository(InveTimeDB db) : base(db) { }
    }
}
