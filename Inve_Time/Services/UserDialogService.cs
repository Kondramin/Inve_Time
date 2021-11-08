using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Inve_Time.ViewModels;
using Inve_Time.Views.Windows;
using System.Windows;

namespace Inve_Time.Services
{
    internal class UserDialogService : IUserDialog
    {
        private readonly IRepository<Position> _PositionRepository;
        private readonly IShowPasswordWindowsService _ShowPasswordWindowService;
        private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;
        private readonly IRepository<Category> _CategoryRepos;

        public UserDialogService(
            IRepository<Position> PositionRepository,
            IShowPasswordWindowsService ShowPasswordWindowService,
            IRepository<CategorySearchWord> CategorySearchWordRepository,
            IRepository<Category> CategoryRepos
            )
        {
            _PositionRepository = PositionRepository;
            _ShowPasswordWindowService = ShowPasswordWindowService;
            _CategorySearchWordRepository = CategorySearchWordRepository;
            _CategoryRepos = CategoryRepos;
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

            category.Id = categoryEditorWindowViewModel.CategoryId;
            category.Name = categoryEditorWindowViewModel.CategoryName;

            return true;
        }


        public bool EditProduct(ProductInfo productInfo)
        {
            ProductEditorWindowViewModel productEditorWindowViewModel = new(productInfo, _CategoryRepos);
            ProductEditorWindow productEditorWindow = new()
            {
                DataContext = productEditorWindowViewModel,
                Title = (productInfo.Name is null) ? "Создание товара" : "Редактирование товара"
            };

            if (productEditorWindow.ShowDialog() != true) return false;

            productInfo.Name = productEditorWindowViewModel.ProductName;
            productInfo.VendorCode = productEditorWindowViewModel.ProductVendorCode;
            productInfo.Barcode = productEditorWindowViewModel.ProductBarcode;
            productInfo.Cost = productEditorWindowViewModel.ProductCost;
            productInfo.Category = productEditorWindowViewModel.SelectedProductCategory;

            return true;
        }


        public bool EditInventarisationEvent (InventarisationEvent inventarisationEvent)
        {


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

