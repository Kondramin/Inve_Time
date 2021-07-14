using System.Threading.Tasks;

namespace Inve_Time.Services.ServiceInterfaces
{
    interface IAutoChoseCategoryProductService
    {

        /// <summary>
        /// Automatically detects product category
        /// </summary>
        void IdentifyCategory();

        /// <summary>
        /// Automatically detects product category async
        /// </summary>
        /// <returns></returns>
        Task IdentifyCategoryAsync();
    }
}
