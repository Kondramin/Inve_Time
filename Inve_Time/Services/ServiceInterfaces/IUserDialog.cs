using Inve_Time.Models;

namespace Inve_Time.Services.ServiceInterfaces
{
    /// <summary>Interface of user dialog service</summary>
    interface IUserDialog
    {
        /// <summary>Show MessageBox to confirm some action</summary>
        /// <param name="Information">Information in MessageBox</param>
        /// <param name="Caption">Caption of MessageBox</param>
        /// <returns>true/false</returns>
        bool ConfirmInformation(string Information, string Caption);

        /// <summary>Show MessageBox about warning to user</summary>
        /// <param name="Warning">Message of warning</param>
        /// <param name="Caption">Caption of MessageBox</param>
        /// <returns>true/false</returns>
        bool ConfirmWarning(string Warning, string Caption);

        /// <summary>Show MessageBox about error to user</summary>
        /// <param name="Error">Message of warning</param>
        /// <param name="Caption">Caption of MessageBox</param>
        /// <returns>true/false</returns>
        bool ConfirmError(string Error, string Caption);

        /// <summary>Show dialog window to edit employee</summary>
        /// <param name="employee">Entity of Employee</param>
        /// <param name="employeeModel"></param>
        /// <returns>true/false</returns>
        bool EditEpmloyee(EmployeeModel employeeModel);

        /// <summary>Show dialog window to edit category</summary>
        /// <param name="category">Entity of Category</param>
        /// <returns>true/false</returns>
        bool EditCategory(CategoryModel category);

        /// <summary>Show dialog window to edit product</summary>
        /// <param name="productBase">Entity of ProdutcBase</param>
        /// <returns>true/false</returns>
        bool EditProduct(ProductModel productBase);
    }
}
