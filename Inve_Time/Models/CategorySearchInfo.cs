using Inve_Time.DataBase.dll.Entities;
using System.Collections.Generic;

namespace Inve_Time.Models
{
    internal class CategorySearchInfo
    {
        public Category Category { get; set; } 

        public List<HelpCategorySearch> helpCategorySearches { get; set; }

    }
}
