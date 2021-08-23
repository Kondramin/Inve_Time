using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;
using System.Windows;

namespace Inve_Time.Services
{
    class UserDialogService : IUserDialog
    {
        private readonly IRepository<Position> _PositionRepository;
        private readonly IRepository<Password> _PasswodRepository;

        public UserDialogService(
            IRepository<Position> PositionRepository,
            IRepository<Password> PasswodRepository
            )
        {
            _PositionRepository = PositionRepository;
            _PasswodRepository = PasswodRepository;
        }

        

        public bool EditEpmloyee(Employee employee)
        {
            //TODO:Refactoring
            EmpEditorWindowViewModel employee_editor_viewModel = new(employee, _PositionRepository, _PasswodRepository);


            EmpEditorWindow employee_editor_window = new()
            {
                DataContext = employee_editor_viewModel
            };


            if (employee_editor_window.ShowDialog() != true)
            {
                return false;
            }

            employee.Id = employee_editor_viewModel.EmpId;
            employee.SecondName = employee_editor_viewModel.EmpSecondName;
            employee.Name = employee_editor_viewModel.EmpName;
            employee.Patronymic = employee_editor_viewModel.EmpPatronymic;
            employee.Phone = employee_editor_viewModel.EmpPhone;
            employee.Email = employee_editor_viewModel.EmpEmail;
            employee.Login = employee_editor_viewModel.EmpLogin;
            employee.Position = employee_editor_viewModel.SelectedPosition;

            return true;
        }


        public bool ConfirmInformation(string Information, string Caption) => MessageBox.Show(
            Information, Caption,
            MessageBoxButton.YesNo,
            MessageBoxImage.Information)
            == MessageBoxResult.Yes;
        


        public bool ConfirmWarning(string Warning, string Caption) => MessageBox.Show(
            Warning, Caption,
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning)
            == MessageBoxResult.Yes;


        public bool ConfirmError(string Error, string Caption) => MessageBox.Show(
            Error, Caption,
            MessageBoxButton.YesNo,
            MessageBoxImage.Error)
            == MessageBoxResult.Yes;
    }
}
    
