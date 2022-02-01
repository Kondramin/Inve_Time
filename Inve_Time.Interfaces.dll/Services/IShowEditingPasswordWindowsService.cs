namespace Inve_Time.Interfaces.Services
{
    public interface IShowEditingPasswordWindowsService
    {
        /// <summary>Show window to change password</summary>
        /// <returns>true/false</returns>
        public bool ShowEditingPasswordWindows(int employeeId);
    }
}
