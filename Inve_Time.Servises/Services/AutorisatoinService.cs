using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Interfaces.Services;
using System;
using System.Linq;

namespace Inve_Time.Servises.Services
{
    internal class AutorisatoinService : IAutorisatoinService
    {
        private readonly IRepository<Employee> _EmployeeRepository;

        public AutorisatoinService(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        private int employeeId { get; set; }



        public bool ValidateLoginAndPassword(string login, string password)
        {
            throw new NotImplementedException();
        }



        public bool VaidateLogin(string login)
        {
            if(!_EmployeeRepository.Items.Any(emp => emp.Login == login)) return false;

            employeeId = _EmployeeRepository.Items.FirstOrDefault(emp => emp.Login == login).Id;
            return true;
        }

        

        public bool ValidatePassword(int employeeId, string password)
        {
            if(_EmployeeRepository.Items.Include.)

            return true;
        }
    }
}
