using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories
{
    internal class PositionRepository : DbRepository<Position>
    {
        public PositionRepository(InveTimeDB db) : base(db) { }



        public override IQueryable<Position> Items => base.Items
            .Include(item => item.Employees)
            ;

    }
}
