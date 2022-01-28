using System.ComponentModel.DataAnnotations.Schema;

namespace Inve_Time.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }



        public CategoryModel Category { get; set; }
    }
}
