namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Srvice to show change password window</summary>
    interface IShowPasswordWindowsService
    {
        /// <summary>Show window to change password</summary>
        /// <returns>true/false</returns>
        public bool ShowChangePasswordWondow(int EmpId);
    }
}
