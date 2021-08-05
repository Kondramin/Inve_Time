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
    internal class AutorisationService : IAutorisationService
    {
        private readonly IRepository<Employee> _EmployeeRepository;



        public AutorisationService(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }



        public EmpBaseInfo AutorisatedUser { get; set; } = null;



        public bool ValidateLoginAndPassword(string login, string password)
        {   
            if (!(_EmployeeRepository.Items.Select(p => p.Login).Contains(login)))
            {
                MessageBox.Show("Не верный логин");
                return false;
            }
            else if (!(_EmployeeRepository.Items.Where(p => p.Login == login).Select(p => p.Password.Name).Contains(password)))
            {
                MessageBox.Show("Не верный пароль");
                return false;
            }
            AutorisatedUser = SaveAutorisatedUser(login, password);
            return true;
        }

        public EmpBaseInfo SaveAutorisatedUser(string login, string password) => new EmpBaseInfo(_EmployeeRepository.Items.SingleOrDefault(p => p.Login == login && p.Password.Name == password));
        
    }
}
