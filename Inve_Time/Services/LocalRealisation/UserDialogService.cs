using Inve_Time.Interfaces.Services;
using Inve_Time.Models;
using System.Windows;

namespace Inve_Time.Services.LocalRealisation
{
    internal class UserDialogService : IUserDialog
    {
        //private readonly IRepository<PositionModel> _PositionRepository;
        //private readonly IShowPasswordWindowsService _ShowPasswordWindowService;
        //private readonly IRepository<CategorySearchWordModel> _CategorySearchWordRepository;
        //private readonly IRepository<CategoryModel> _CategoryRepos;

        public UserDialogService(
            //IRepository<PositionModel> PositionRepository,
            //IShowPasswordWindowsService ShowPasswordWindowService,
            //IRepository<CategorySearchWordModel> CategorySearchWordRepository,
            //IRepository<CategoryModel> CategoryRepos
            )
        {
            //_PositionRepository = PositionRepository;
            //_ShowPasswordWindowService = ShowPasswordWindowService;
            //_CategorySearchWordRepository = CategorySearchWordRepository;
            //_CategoryRepos = CategoryRepos;
        }



        public bool EditEpmloyee(EmployeeModel employeeModel)
        {
            //EmployeeEditorWindowViewModel employee_editor_viewModel = new(employee, _PositionRepository, _ShowPasswordWindowService);


            //EmployeeEditorWindow employee_editor_window = new()
            //{
            //    DataContext = employee_editor_viewModel
            //};


            //if (employee_editor_window.ShowDialog() != true) return false;


            //employee.Id = employee_editor_viewModel.EmpId;
            //employee.SecondName = employee_editor_viewModel.EmpSecondName;
            //employee.Name = employee_editor_viewModel.EmpName;
            //employee.Patronymic = employee_editor_viewModel.EmpPatronymic;
            //employee.Phone = employee_editor_viewModel.EmpPhone;
            //employee.Email = employee_editor_viewModel.EmpEmail;
            //employee.Login = employee_editor_viewModel.EmpLogin;
            //employee.Position = employee_editor_viewModel.SelectedPosition;

            return true;
        }


        public bool EditCategory(CategoryModel categoryModel)
        {
            //CategoryEditorWindowViewModel categoryEditorWindowViewModel = new(category);
            //CategoryEditorWindow categoryEditorWindow = new()
            //{
            //    DataContext = categoryEditorWindowViewModel,
            //    Title = (category.Name is null) ? "Создать категорию" : "Редактировать категорию"
            //};

            //if (categoryEditorWindow.ShowDialog() != true) return false;

            //category.Id = categoryEditorWindowViewModel.CategoryId;
            //category.Name = categoryEditorWindowViewModel.CategoryName;

            return true;
        }


        public bool EditProduct(ProductModel productModel)
        {
            //ProductEditorWindowViewModel productEditorWindowViewModel = new(productInfo, _CategoryRepos);
            //ProductEditorWindow productEditorWindow = new()
            //{
            //    DataContext = productEditorWindowViewModel,
            //    Title = (productInfo.Name is null) ? "Создание товара" : "Редактирование товара"
            //};

            //if (productEditorWindow.ShowDialog() != true) return false;

            //productInfo.Name = productEditorWindowViewModel.ProductName;
            //productInfo.VendorCode = productEditorWindowViewModel.ProductVendorCode;
            //productInfo.Barcode = productEditorWindowViewModel.ProductBarcode;
            //productInfo.Cost = productEditorWindowViewModel.ProductCost;
            //productInfo.Category = productEditorWindowViewModel.SelectedProductCategory;

            return true;
        }


        public bool EditInventarisationEvent (InventoryEventModel inventoryEventModel)
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

        public bool EditEpmloyee(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public bool EditCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public bool EditProduct(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}

