using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Category : NamedEntity
    {
        public ICollection<ProductInfo> Products { get; set; }
        public ICollection<CategorySearchWord> CategorySearchWords { get; set; }
    }
}
