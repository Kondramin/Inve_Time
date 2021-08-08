using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;

namespace Inve_Time.Services
{
    class UserDialogService : IUserDialog
    {
        private readonly IRepository<Position> _PositionRep;
        private readonly IRepository<Password> _PasswodRep;

        public UserDialogService(
            IRepository<Position> PositionRep,
            IRepository<Password> PasswodRep
            )
        {
            _PositionRep = PositionRep;
            _PasswodRep = PasswodRep;
        }

        public bool Edit(Employee emp)
        {
            //TODO:Refactoring
            var emp_editor_viewModel = new EmpEditorWindowViewModel(emp, _PositionRep, _PasswodRep);


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
            emp.Position = emp_editor_viewModel.SelectedPosition;
            //emp.Password.Name = emp_editor_viewModel
            


            return true;
        }
    }
}
