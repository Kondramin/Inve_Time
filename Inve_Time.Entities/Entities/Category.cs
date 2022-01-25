using Inve_Time.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.Entities.Entities
{
    public class Category : NamedEntity
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<CategorySearchWord> CategorySearchWords { get; set; }
    }
}
