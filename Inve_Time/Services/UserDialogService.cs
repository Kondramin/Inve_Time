using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;

namespace Inve_Time.Services
{
    class UserDialogService : IUserDialog
    {
        public bool Edit(Employee emp)
        {
            //TODO:Refactoring
            var emp_editor_viewModel = new EmpEditorWindowViewModel(emp);


            var emp_editor_window = new EmpEditorWindow
            {
                DataContext = emp_editor_viewModel
            };


            if (emp_editor_window.DialogResult != true) return false;


            //emp.Id = emp_editor_viewModel.EmployeeId;
            //emp.SecondName = emp_editor_viewModel.EmployeeSecondName;
            //emp.Name = emp_editor_viewModel.EmployeeName;
            //emp.Patronymic = emp_editor_viewModel.EmployeePatronymic;
            //emp.Phone = emp_editor_viewModel.EmployeePhone;
            //emp.Email = emp_editor_viewModel.EmployeeEmail;
            //emp.Login = emp_editor_viewModel.EmployeeLogin;
            //emp.Password.Name = emp_editor_viewModel.EmployeePassword;
            //emp.Position.Name = emp_editor_viewModel.EmployeePositionName;


            return true;
        }
    }
}
