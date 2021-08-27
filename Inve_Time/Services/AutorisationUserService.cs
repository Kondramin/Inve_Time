using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Models;
using Inve_Time.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace Inve_Time.Services
{
    internal class AutorisationUserService : IAutorisationUserService
    {
        private readonly IRepository<Employee> _EmployeeRepository;



        public AutorisationUserService(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }



        public EmpBaseInfo AutorisatedUser { get; set; }

        public Employee PossibleEmployee { get; set; }


        public bool ValidateLoginAndPassword(string login, string password)
        {
            if (!VaidateLogin(login))
            {
                MessageBox.Show("Не верный логин");
                return false;
            }
            else if (!ValidatePassword(PossibleEmployee.Id, password))
            {
                MessageBox.Show("Не верный пароль");
                return false;
            }
            AutorisatedUser = new(PossibleEmployee);
            return true;
        }

        public bool VaidateLogin(string login)
        {
            if (login is null) return false;
            if (!_EmployeeRepository.Items.Select(e => e.Login).Contains(login)) return false;
            PossibleEmployee = _EmployeeRepository.Items.FirstOrDefault(e => e.Login == login);
            return true;
        }

        public bool ValidatePassword(int employeeId, string password)
        {
            if (password is null) return false;
            var employee = _EmployeeRepository.Items.Include(item => item.Password).FirstOrDefault(e => e.Id == employeeId);
            if (!(employee.Password.Name == password)) return false;
            return true;
        }
    }
}
