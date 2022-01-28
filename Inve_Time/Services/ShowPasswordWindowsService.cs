using Inve_Time.Services.ServiceInterfaces;

namespace Inve_Time.Services
{
    internal class ShowPasswordWindowsService : IShowPasswordWindowsService
    {
        //private readonly IRepository<Employee> _EmployeeRepository;
        //private readonly IEditPasswordService _EditPasswordService;
        //private readonly IAutorisationUserService _AutorisationUserService;

        public ShowPasswordWindowsService(
            //IRepository<Employee> EmployeeRepository,
            //IEditPasswordService EditPasswordService,
            //IAutorisationUserService AutorisationUserService
            )
        {
            //_EmployeeRepository = EmployeeRepository;
            //_EditPasswordService = EditPasswordService;
            //_AutorisationUserService = AutorisationUserService;
        }

        public bool ShowChangePasswordWondow(int EmpId)
        {
            throw new System.NotImplementedException();
        }



        //private Employee Employee { get; set; }



        //public bool ShowChangePasswordWondow(int EmpId)
        //{
        //    if (!_EmployeeRepository.Items.Select(e => e.Id).Contains(EmpId))
        //    {
        //        MessageBox.Show("Сотрудник отсутствует/не найден.");
        //        return false;
        //    }


        //    Employee = _EmployeeRepository.Items.Include(item => item.Password).FirstOrDefault(e => e.Id == EmpId);


        //    ChangePasswordWindowViewModel changePasswordWindowViewModel = new(EmpId, _EditPasswordService, _AutorisationUserService);


        //    ChangePasswordWindow changePasswordWindow = new()
        //    {
        //        DataContext = changePasswordWindowViewModel,

        //        Title = (Employee.Password is null) ? "Создать пароль" : "Изменить пароль",

        //        OldPwdBox =
        //        {
        //            IsEnabled = Employee.Password is not null
        //        }
        //    };


        //    return changePasswordWindow.ShowDialog() == true;
        //}
    }
}
