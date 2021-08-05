using Inve_Time.Models;

namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Service to autorisation user in application</summary>
    interface IAutorisationService
    {
        /// <summary>Property, contained info about autorisated user</summary>
        EmpBaseInfo AutorisatedUser { get; set; }

        /// <summary>Return entity of autorisated user</summary>
        /// <param name="login">Input login</param>
        /// <param name="password">Input password</param>
        /// <returns>Autorisated user</returns>
        EmpBaseInfo SaveAutorisatedUser(string login, string password);

        /// <summary>Validate user in app. If return "true" - method "SaveAutorisatedUser" will be called automatically</summary>
        /// <param name="login">Input login</param>
        /// <param name="password">Input password</param>
        /// <returns>true/false</returns>
        bool ValidateLoginAndPassword(string login, string password);
    }
}
