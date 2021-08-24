namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Srvice to change password</summary>
    interface IChangePasswordService
    {
        /// <summary>Change password</summary>
        /// <returns>true/false</returns>
        public bool ChangePassword(int EmpId);
    }
}
