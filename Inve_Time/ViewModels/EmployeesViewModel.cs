using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;

namespace Inve_Time.ViewModels
{
    class EmployeesViewModel : ViewModel
    {
        private IRepository<Employee> _EmployeeRepository;

        public EmployeesViewModel(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }
    }
}
