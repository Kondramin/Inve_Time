using Inve_Time.DataBase.dll.Entities.Base;

namespace Inve_Time.DataBase.dll.Entities
{
    public class HelpCategorySearch : NamedEntity
    {
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
