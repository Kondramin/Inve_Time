namespace Inve_Time.Interfaces.Services
{
    public interface IUserDialog
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
        /// <param name="employeeId">Id of employee</param>
        /// <returns>true/false</returns>
        bool EditEpmloyee(int employeeId);

        /// <summary>Show dialog window to edit category</summary>
        /// <param name="categoryId">Entity of Category</param>
        /// <returns>true/false</returns>
        bool EditCategory(int categoryId);

        /// <summary>Show dialog window to edit product</summary>
        /// <param name="productId">Entity of ProdutcBase</param>
        /// <returns>true/false</returns>
        bool EditProduct(int productId);
    }
}