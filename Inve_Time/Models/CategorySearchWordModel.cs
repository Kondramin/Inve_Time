using Inve_Time.Models.Base;

namespace Inve_Time.Models
{
    public class CategorySearchWordModel : EntityModel
    {
        public string Name { get; set; }


        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
