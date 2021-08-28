namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Edit password service</summary>
    interface IEditPasswordService
    {
        /// <summary>Edit password. If user haven't password - create it</summary>
        /// <param name="employeeId">Id employee</param>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <param name="confirmNewPassword">Confirm new password</param>
        /// <returns>true/false</returns>
        bool EditPassword(int employeeId, string oldPassword, string newPassword, string confirmNewPassword);
    }
}
