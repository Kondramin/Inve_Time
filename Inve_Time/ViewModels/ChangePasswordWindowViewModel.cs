using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using System;

namespace Inve_Time.ViewModels
{
    /// <summary>ViewModel of ChangePasswordWindow</summary>
    class ChangePasswordWindowViewModel : ViewModel
    {
        private readonly IRepository<Employee> _EmployeeRepository;

        public ChangePasswordWindowViewModel(int employeeId, IRepository<Employee> EmployeeRepository)
        {
            EmpId = employeeId;
            _EmployeeRepository = EmployeeRepository;
        }
        
        public ChangePasswordWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }

        public int EmpId { get; }

    }
}
