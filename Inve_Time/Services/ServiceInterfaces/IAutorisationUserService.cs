using Inve_Time.Models;

namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Service to autorisation user in application</summary>
    interface IAutorisationUserService
    {
        /// <summary>Property, contained info about autorisated user</summary>
        EmpBaseInfo AutorisatedUser { get; set; }

        /// <summary>Validate user in app. If return "true" - prop "AutorisatedUser" will be include info about autorisated user</summary>
        /// <param name="login">Input login</param>
        /// <param name="password">Input password</param>
        /// <returns>true/false</returns>
        bool ValidateLoginAndPassword(string login, string password);

        /// <summary>Validate login user</summary>
        /// <param name="login">User login</param>
        /// <returns>true/false</returns>
        bool VaidateLogin(string login);

        /// <summary>Validate password of user</summary>
        /// <param name="employeeId">Id of possible user</param>
        /// <param name="password">User password</param>
        /// <returns>true/false</returns>
        bool ValidatePassword(int employeeId, string password);
    }
}
