using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Category : NamedEntity
    {
        public ICollection<ProductBase> Products { get; set; }
        public ICollection<HelpCategorySearch> HelpCategorySearchers { get; set; }
    }
}
