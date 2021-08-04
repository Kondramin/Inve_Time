using Inve_Time.Models;

namespace Inve_Time.Services.ServiceInterfaces
{
    interface IAutorisationService
    {
        /// <summary>
        /// Property, contained info about autorisated user
        /// </summary>
        EmployeeBaseInfo AutorisatedUser { get; set; }

        /// <summary>
        /// Save entity autorisated user
        /// </summary>
        /// <param name="login">Input login</param>
        /// <param name="password">Input password</param>
        /// <returns></returns>
        EmployeeBaseInfo SaveAutorisatedUser(string login, string password);

        /// <summary>
        /// Validate user in app. If return "true" - method "SaveAutorisatedUser" will be called automatically
        /// </summary>
        /// <param name="login">Input login</param>
        /// <param name="password">Input password</param>
        /// <returns></returns>
        bool ValidateLoginAndPassword(string login, string password);
    }
}
