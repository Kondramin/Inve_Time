using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

namespace Inve_Time.Services
{
    internal class ChangePasswordService : IChangePasswordService
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IRepository<Password> _PasswodrRepository;
        private readonly IAutorisationService _AutorisationService;

        public ChangePasswordService(
            IRepository<Employee> EmployeeRepository,
            IRepository<Password> PasswodrRepository,
            IAutorisationService AutorisationService

            )
        {
            _EmployeeRepository = EmployeeRepository;
            _PasswodrRepository = PasswodrRepository;
            _AutorisationService = AutorisationService;
        }


        private Employee Employee { get; set; }



        public bool ChangePassword(int EmpId)
        {
            if (!_EmployeeRepository.Items.Select(e => e.Id).Contains(EmpId))
            {
                MessageBox.Show("Сотрудник отсутствует/не найден");
                return false;
            }


            Employee = _EmployeeRepository.Items.Include(item => item.Password).FirstOrDefault(e => e.Id == EmpId);


            ChangePasswordWindowViewModel changePasswordWindowViewModel = new(Employee.Id, _EmployeeRepository);

            
            ChangePasswordWindow changePasswordWindow = new()
            {
                
                DataContext = changePasswordWindowViewModel,
                
                
                Title = (Employee.Password is null) ? "Создать пароль" : "Изменить пароль",
                
                
                OldPwdTextBlock =
                {
                    IsEnabled = Employee.Password is not null
                },
                
                
                OldPwdBox =
                {
                    IsEnabled = Employee.Password is not null
                }
            };


            if (changePasswordWindow.ShowDialog() != true)
            {
                return false;
            }

            return true;
        }



        public bool SetPassword(string oldPassword , string newPassword, string confirmNewPassword)
        {
            if (Employee.Password is null)
            {
                if (newPassword == confirmNewPassword)
                {
                    Password password = new()
                    {
                        Name = newPassword,
                        EmployeeId = Employee.Id
                    };
                    Employee.Password = _PasswodrRepository.Add(password);
                    _EmployeeRepository.Update(Employee);
                    return true;
                }
            }

            if (Employee.Password.Name == oldPassword)
            {
                if (newPassword == confirmNewPassword)
                {
                    Password password = new()
                    {
                        Name = newPassword,
                        EmployeeId = Employee.Id
                    };

                    _PasswodrRepository.Update(password);

                    return true;
                }
            }

            return false;
        }
       
    }
}
