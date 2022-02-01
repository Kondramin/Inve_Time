using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inve_Time.Services.Services
{
    internal class EditPasswordService : IEditPasswordService
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IRepository<Password> _PasswordRepository;

        public EditPasswordService(IRepository<Employee> employeeRepository, IRepository<Password> PasswordRepository)
        {
            _EmployeeRepository = employeeRepository;
            _PasswordRepository = PasswordRepository;
        }

        public bool EditPassword(int employeeId, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (!_EmployeeRepository.Items.Any(emp=>emp.Id==employeeId)) return false;
            if (newPassword != confirmNewPassword) return false;

            var employee = _EmployeeRepository.Items.Include(emp => emp.Password).SingleOrDefault(emp => emp.Id == employeeId);

            if (employee.Password is null)
            {
                 return NewPassword(employee, newPassword, confirmNewPassword);
            }
            throw new System.NotImplementedException();
        }

        //public bool EditPassword(int employeeId, string oldPassword, string newPassword, string confirmNewPassword)
        //{
        //    //var employee = _EmployeeRepository.Items.Include(item => item.Password).FirstOrDefault(e => e.Id == employeeId);

        //    //if (employee.Password is null)
        //    //{
        //    //    return NewPassword(employee, newPassword, confirmNewPassword);
        //    //}

        //    //return ChangePassword(employee, oldPassword, newPassword, confirmNewPassword);
        //}

        private bool NewPassword(Employee employee, string newPassword, string confirmNewPassword)
        {
            if (newPassword != confirmNewPassword) return false;

            var password = new Password()
            {
                Name = newPassword,
                EmployeeId = employee.Id,
                Employee = employee
            };
            var addedPassword = _PasswordRepository.Add(password);
            
            employee.PasswodrId = addedPassword.Id;
            employee.Password = addedPassword;
            
            _EmployeeRepository.Update(employee);

            return true;
        }


        private bool ChangePassword(Employee employee, string oldPassword, string newPassword, string confirmNewPassword)
        {
            if (newPassword != confirmNewPassword) return false;

            if (employee.Password.Name != oldPassword) return false;
            
            var editingPassword = _PasswordRepository.Get(employee.Password.Id);

            //TODO: Доделать реализацию сервиса, зарегистрировать, убрать локальную реализацию
            return true;
        }


        //private bool ChangePassword(Employee employee, string oldPassword, string newPassword, string confirmNewPassword)
        //{
        //    if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmNewPassword)) return false;

        //    if (employee.Password.Name == oldPassword)
        //    {
        //        if (newPassword == confirmNewPassword)
        //        {
        //            Password password=_PasswordRepository.Get(employee.Password.Id);
        //            password.Name = newPassword;
        //            _PasswordRepository.Update(password);

        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
