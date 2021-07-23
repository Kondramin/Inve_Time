using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    class EmployeesViewModel : ViewModel
    {
        private IRepository<Employee> _EmployeeRepository;



        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();



        public EmployeesViewModel(IRepository<Employee> employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }



        #region Commands

        #region Command GetEmployeesCommand - Get Employees data from database

        /// <summary>Get Employees data from database</summary>
        private ICommand _GetEmployeesCommand;


        /// <summary>Get Employees data from database</summary>
        public ICommand GetEmployeesCommand => _GetEmployeesCommand
            ??= new LambdaCommandAsync(OnGetEmployeesCommandExequted);

        /// <summary>Execution logic - Get Employees data from database</summary>
        /// <param name="p"></param>
        public async Task OnGetEmployeesCommandExequted(object p)
        {
            await DownloadEpmloyeesInfoAsync();
        }

        private async Task DownloadEpmloyeesInfoAsync()
        {

            var employeesInfo_query = _EmployeeRepository.Items;

            Employees.Clear();

            foreach (var employees in await employeesInfo_query.ToArrayAsync())
            {
                Employees.Add(employees);
            }
        }

        #endregion

        #endregion

    }
}
