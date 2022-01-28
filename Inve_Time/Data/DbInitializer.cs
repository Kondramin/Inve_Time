using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
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

            if (!await _db.Employees.AnyAsync())
            {
                var employee = new Employee() { Id = 1, Login = "Admin", PasswodrId = 1 };
                var passwodr = new Password() { Id = 1, Name = "Admin".GetHashCode().ToString()};

                _db.Employees.Add(employee);
                _db.Passwords.Add(passwodr);

                await _db.SaveChangesAsync();
            }
        }
    }
}
