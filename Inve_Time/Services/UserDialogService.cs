using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;

namespace Inve_Time.Services
{
    class UserDialogService : IUserDialog
    {

        //TODO:Refactoring
        public bool Edit(Employee employee)
        {

            var employee_editor_viewModel = new EpmloyeeEditorWindowViewModel(employee);

            var employee_editor_window = new EpmloyeeEditorWindow
            {
                DataContext = employee_editor_viewModel
            };

            if (employee_editor_window.DialogResult != true) return false;


            employee.Id = employee_editor_viewModel.EmployeeId;
            employee.SecondName = employee_editor_viewModel.EmployeeSecondName;
            employee.Name = employee_editor_viewModel.EmployeeName;
            employee.Patronymic = employee_editor_viewModel.EmployeePatronymic;
            employee.Phone = employee_editor_viewModel.EmployeePhone;
            employee.Email = employee_editor_viewModel.EmployeeEmail;
            employee.Login = employee_editor_viewModel.EmployeeLogin;
            employee.Password.Name = employee_editor_viewModel.EmployeePassword;
            employee.Position.Name = employee_editor_viewModel.EmployeePositionName;


            return false;
        }
    }
}
