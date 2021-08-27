using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Edit password service</summary>
    interface IEditPasswordService
    {
        /// <summary>Edit password. If user haven't password - create it</summary>
        /// <param name="employeeId"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        /// <returns></returns>
        bool EditPassword(int employeeId, string oldPassword, string newPassword, string confirmNewPassword);
    }
}
