using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Interfaces.Services;
using Inve_Time.ViewModels.WindowsViewModels.EditWindowsViewModels;
using Inve_Time.Views.Windows.EditWindows;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace Inve_Time.Services.LocalRealisation
{
    internal class ShowEditingPasswordWindowsService : IShowEditingPasswordWindowsService
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IEditPasswordService _EditPasswordService;
        //private readonly IAutorisationUserService _AutorisationUserService;

        public ShowEditingPasswordWindowsService(
            IRepository<Employee> EmployeeRepository,
            IEditPasswordService EditPasswordService
            //IAutorisationUserService AutorisationUserService
            )
        {
            _EmployeeRepository = EmployeeRepository;
            _EditPasswordService = EditPasswordService;
            //_AutorisationUserService = AutorisationUserService;
        }

       
        public bool ShowEditingPasswordWindows(int employeeId)
        {
            if (!_EmployeeRepository.Items.Any(emp => emp.Id == employeeId))
            {
                MessageBox.Show("Сотрудник отсутствует/не найден.");
                return false;
            }

            var employee = _EmployeeRepository.Items.Include(emp => emp.Password).FirstOrDefault(emp => emp.Id == employeeId);

            ChangePasswordWindowViewModel changePasswordWindowViewModel = new ChangePasswordWindowViewModel(employee.Id, _EditPasswordService);
            ChangePasswordWindow changePasswordWindow = new()
            {
                DataContext = changePasswordWindowViewModel,

                Title = (employee.Password is null) ? "Создать пароль" : "Изменить пароль",

                OldPwdBox =
                {
                    IsEnabled = employee.Password is not null
                }
            };

            return changePasswordWindow.ShowDialog() == true;

        }

    }
}
