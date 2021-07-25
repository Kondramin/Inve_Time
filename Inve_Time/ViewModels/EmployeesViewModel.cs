using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Models;
using Inve_Time.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    class EmployeesViewModel : ViewModel
    {
        private IRepository<Employee> _EmployeeRepository;



        public ObservableCollection<EmpBaseInfo> Employees { get; } = new ObservableCollection<EmpBaseInfo>();



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
            //TODO: реализовать сложную выборку.

            var employeesInfo_query = _EmployeeRepository.Items;//.Select(e => new { id = e.Id, fName = e.Name, sName = e.SecondName, pName = e.Patronymic, email = e.Email }).GroupBy(e => e.sName);



            Employees.Clear();

            foreach (var employees in await employeesInfo_query.ToArrayAsync())
            {
                EmpBaseInfo epmBaseInfo = new EmpBaseInfo()
                {
                    Id = employees.Id,
                    _FIO = new FIO() { Name = employees.Name, SecName = employees.SecondName, Part = employees.Patronymic},
                    Email = employees.Email//, Phone = employees.Phone

                };

                Employees.Add(epmBaseInfo);
            }
        }

        #endregion

        #endregion

    }
}
