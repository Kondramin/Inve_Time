using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inve_Time.Interfaces.Services
{
    public interface IAutoChoseCategoryProductService
    {
        // <summary>Automatically detects product category</summary>
        void IdentifyCategory();

        /// <summary>Automatically detects product category async</summary>
        /// <returns></returns>
        Task IdentifyCategoryAsync();
    }
}
