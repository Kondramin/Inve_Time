using Inve_Time.DataBase.dll.Entities;

namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Interface of user dialog service</summary>
    interface IUserDialog
    {
        /// <summary>Edit employee</summary>
        /// <param name="employee">Entity of Employee</param>
        /// <returns>true/false</returns>
        bool Edit(Employee employee);
    }
}
