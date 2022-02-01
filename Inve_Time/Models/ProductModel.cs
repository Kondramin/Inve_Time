using Inve_Time.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inve_Time.Models
{
    public class ProductModel : EntityModel
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }



        public CategoryModel Category { get; set; }
    }
}
