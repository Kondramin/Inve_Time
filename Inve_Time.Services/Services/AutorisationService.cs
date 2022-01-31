using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Services.Services
{
    internal class AutorisationService : IAutorisationService
    {
        private readonly IRepository<Employee> _EmployeeRepository;


        public AutorisationService(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }



        public Employee AutorisatedEmployee { get; set; }


        public bool ValidateLoginAndPassword(string login, string password)
        {
            if (!VaidateLogin(login)) return false;
            if (!ValidatePassword(password)) return false;

            return true;
        }



        public bool VaidateLogin(string login)
        {
            if (!_EmployeeRepository.Items.Any(emp => emp.Login == login)) return false;
            AutorisatedEmployee = _EmployeeRepository.Items.Include(emp => emp.Password).FirstOrDefault(emp => emp.Login == login);

            return true;
        }



        public bool ValidatePassword(string password)
        {
            if (AutorisatedEmployee == null) return false;
            if (AutorisatedEmployee.Password.Name != password) return false;

            return true;
        }
    }
}
