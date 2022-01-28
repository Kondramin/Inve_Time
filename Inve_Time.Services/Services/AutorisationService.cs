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



        private int employeeId { get; set; }



        public bool ValidateLoginAndPassword(string login, string password)
        {
            if (!VaidateLogin(login)) return false;
            if (!ValidatePassword(employeeId, password)) return false;

            return true;
        }



        public bool VaidateLogin(string login)
        {
            if (!_EmployeeRepository.Items.Any(emp => emp.Login == login)) return false;
            employeeId = _EmployeeRepository.Items.FirstOrDefault(emp => emp.Login == login).Id;

            return true;
        }



        public bool ValidatePassword(int employeeId, string password)
        {
            var employee = _EmployeeRepository.Items.FirstOrDefault(emp => emp.Id == employeeId);
            if (employee == null) return false;
            if (employee.Password.Name != password.GetHashCode().ToString()) return false;

            return true;
        }
    }
}
