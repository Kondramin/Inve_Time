using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Category : NamedEntity
    {
        public List<Product> Products { get; set; }
        public List<HelpCategorySearch> HelpCategorySearchers { get; set; }
    }
}
