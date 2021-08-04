using Inve_Time.DataBase.dll.Entities;

namespace Inve_Time.Services.ServiceInterfaces
{
    interface IAutorisationService
    {
        /// <summary>
        /// Property, contained info about autorisated user
        /// </summary>
        Employee AutorisatedUser { get; set; }

        /// <summary>
        /// Save entity autorisated user
        /// </summary>
        /// <param name="login">Input login</param>
        /// <param name="password">Input password</param>
        /// <returns></returns>
        Employee SaveAutorisatedUser(string login, string password);

        /// <summary>
        /// Validate user in app. If return "true" - method "SaveAutorisatedUser" will be called automatically
        /// </summary>
        /// <param name="login">Input login</param>
        /// <param name="password">Input password</param>
        /// <returns></returns>
        bool ValidateLoginAndPassword(string login, string password);
    }
}
