using Inve_Time.Entities.Base;

namespace Inve_Time.Entities.Entities
{
    public class CategorySearchWord : NamedEntity
    {
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
