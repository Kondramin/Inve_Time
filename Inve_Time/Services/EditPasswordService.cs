using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Services
{
    class EditPasswordService : IEditPasswordService
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IRepository<Password> _PasswordRepository;

        public EditPasswordService(IRepository<Employee> EmployeeRepository, IRepository<Password> PasswordRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _PasswordRepository = PasswordRepository;
        }

        public bool EditPassword(int employeeId, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (string.IsNullOrEmpty(oldPassword)) return false;
            if (string.IsNullOrEmpty(newPassword)) return false;
            if (string.IsNullOrEmpty(confirmNewPassword)) return false;

            var employee = _EmployeeRepository.Items.Include(item => item.Password).FirstOrDefault(e => e.Id == employeeId);

            if(employee.Password is null)
            {
                if (newPassword == confirmNewPassword)
                {
                    Password password = new()
                    {
                        Name = newPassword,
                        EmployeeId = employee.Id
                    };
                    employee.Password = _PasswordRepository.Add(password);
                    _EmployeeRepository.Update(employee);

                    return true;
                }
            }


            if (employee.Password.Name == oldPassword)
            {
                if (oldPassword == confirmNewPassword)
                {
                    Password password = new()
                    {
                        Name = newPassword
                    };
                    _PasswordRepository.Update(password);

                    return true;
                }
            }

            return false;
        }
    }
}
