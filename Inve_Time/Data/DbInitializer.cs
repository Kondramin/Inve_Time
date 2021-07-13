using Inve_Time.DataBase.dll.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Inve_Time.Data
{
    class DbInitializer
    {
        private readonly InveTimeDB _db;

        public DbInitializer(InveTimeDB db)
        {
            _db = db;
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync();
        }
    }
}
