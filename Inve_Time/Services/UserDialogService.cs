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
                DataContext = emp_editor_viewModel,
                Height = 450,
                Width = 430,
                
            };


            if (emp_editor_window.ShowDialog() != true) return false;


            emp.Id = emp_editor_viewModel.EmpId;
            emp.SecondName = emp_editor_viewModel.EmpSecondName;
            emp.Name = emp_editor_viewModel.EmpName;
            emp.Patronymic = emp_editor_viewModel.EmpPatronymic;
            emp.Phone = emp_editor_viewModel.EmpPhone;
            emp.Email = emp_editor_viewModel.EmpEmail;
            emp.Login = emp_editor_viewModel.EmpLogin;
            //emp.Password.Name = emp_editor_viewModel
            //emp.Position.Name = emp_editor_viewModel


            return true;
        }
    }
}
