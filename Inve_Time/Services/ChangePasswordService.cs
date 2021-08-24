using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inve_Time.Services
{
    internal class ChangePasswordService : IChangePasswordService
    {
        private readonly IRepository<Employee> _EmployeeRepository;

        public ChangePasswordService(IRepository<Employee> EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public bool ChangePassword(int EmpId)
        {
            var employee = _EmployeeRepository.Items.Include(item => item.Password).FirstOrDefault(e => e.Id == EmpId);

            ChangePasswordWindowViewModel changePasswordWindowViewModel = new(EmpId, _EmployeeRepository);

            ChangePasswordWindow changePasswordWindow = new()
            {
                DataContext = changePasswordWindowViewModel,
                Title = (employee.Password is null) ? "Создать пароль" : "Изменить пароль",
                OldPwdTextBlock =
                {
                    IsEnabled = employee.Password is not null
                },
                OldPwdBox =
                {
                    IsEnabled = employee.Password is not null
                }
            };


            if (changePasswordWindow.ShowDialog() != true)
            {
                return false;
            }

            return true;
        }
    }
}
