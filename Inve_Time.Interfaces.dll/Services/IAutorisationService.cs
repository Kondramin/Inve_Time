using Inve_Time.Entities.Entities;

namespace Inve_Time.Interfaces.Services
{
    public interface IAutorisationService
    {
        /// <summary>Get entity completed autorisation</summary>
        Employee AutorisatedEmployee { get; set; }
        /// <summary>Validate user in app</summary>
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
        bool ValidatePassword(string password);
    }
}
