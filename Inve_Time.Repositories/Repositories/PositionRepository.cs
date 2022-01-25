using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Repositories
{
    internal class PositionRepository : DbRepository<Position>
    {


        public override IQueryable<Position> Items => base.Items.Include(item => item.Employees);


        public PositionRepository(InveTimeDB db) : base(db) { }

    }
}
