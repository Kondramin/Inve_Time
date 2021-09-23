using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;
using System.Linq;
using System.Windows;

namespace Inve_Time.Services
{
    internal class UserDialogService : IUserDialog
    {
        private readonly IRepository<Position> _PositionRepository;
        private readonly IShowPasswordWindowsService _ShowPasswordWindowService;

        public UserDialogService(
            IRepository<Position> PositionRepository,
            IShowPasswordWindowsService ShowPasswordWindowService
            )
        {
            _PositionRepository = PositionRepository;
            _ShowPasswordWindowService = ShowPasswordWindowService;
        }



        public bool EditEpmloyee(Employee employee)
        {
            EmployeeEditorWindowViewModel employee_editor_viewModel = new(employee, _PositionRepository, _ShowPasswordWindowService);


            EmployeeEditorWindow employee_editor_window = new()
            {
                DataContext = employee_editor_viewModel
            };


            if (employee_editor_window.ShowDialog() != true) return false;


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


        public bool EditCategory(Category category)
        {
            CategoryEditorWindowViewModel categoryEditorWindowViewModel = new(category);

            CategoryEditorWindow categoryEditorWindow = new()
            {
                DataContext = categoryEditorWindowViewModel,
                Title = (category.Name is null) ? "Создать категорию" : "Редактировать категорию"

            };

            if (categoryEditorWindow.ShowDialog() != true) return false;

            category.Name = categoryEditorWindowViewModel.CategoryName;
            if (category.CategorySearchWords is not null)
            {
                category.CategorySearchWords.Clear();

                foreach (var item in categoryEditorWindowViewModel.CategorySearchWordCollection)
                {
                    category.CategorySearchWords.Add(item);
                }
            }

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

