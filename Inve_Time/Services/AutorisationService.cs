using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Models;
using Inve_Time.Services.ServiceInterfaces;
using System;
using System.Linq;
using System.Windows;

namespace Inve_Time.Services
{
    internal class AutorisationService : IAutorisationService
    {
        private readonly IRepository<Employee> _EmployeeRepository;

        public EmployeeBaseInfo AutorisatedUser { get; set; } = null;

        public AutorisationService(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }




        public bool ValidateLoginAndPassword(string login, string password)
        {
            if (!(_EmployeeRepository.Items.Select(p => p.Login).Contains(login)))
            {
                MessageBox.Show("Не верный логин");
                return false;
            }
            else if (!(_EmployeeRepository.Items.Where(p => p.Login == login).Select(p => p.Password).Contains(password)))
            {
                MessageBox.Show("Не верный пароль");
                return false;
            }
            AutorisatedUser = SaveAutorisatedUser(login, password);
            return true;
        }

        public EmployeeBaseInfo SaveAutorisatedUser(string login, string password)
        {
            Employee employee = _EmployeeRepository.Items.SingleOrDefault(p => p.Login == login && p.Password == password);
            return new EmployeeBaseInfo
            {
                Id = employee.Id,
                Name = employee.Name,
                SecondName = employee.SecondName,
                Patronymic = employee.Patronymic,
                Phone = employee.Phone,
                Email = employee.Email,
                Position = employee.Position
            };
        }

    }
}
