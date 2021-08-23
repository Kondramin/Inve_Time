using Inve_Time.DataBase.dll.Entities;

namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Interface of user dialog service</summary>
    interface IUserDialog
    {
        /// <summary>Show dialog window to edit employee</summary>
        /// <param name="employee">Entity of Employee</param>
        /// <returns>true/false</returns>
        bool EditEpmloyee(Employee employee);

        /// <summary>Show MessageBox to confirm some action</summary>
        /// <param name="Information">Information in MessageBox</param>
        /// <param name="Caption">Caption of MessageBox</param>
        /// <returns>true/false</returns>
        bool ConfirmInformation(string Information, string Caption);

        /// <summary>Show MessageBox about warning to user</summary>
        /// <param name="Warning">Messege of warning</param>
        /// <param name="Caption">Caption of MessageBox</param>
        /// <returns>true/false</returns>
        bool ConfirmWarning(string Warning, string Caption);

        /// <summary>Show MessageBox about error to user</summary>
        /// <param name="Error">Messege of warning</param>
        /// <param name="Caption">Caption of MessageBox</param>
        /// <returns>true/false</returns>
        bool ConfirmError(string Error, string Caption);
        bool EditPassword(int employeeId);
    }
}
