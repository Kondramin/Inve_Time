using Inve_Time.DataBase.dll.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inve_Time.DataBase.dll.Entities
{
    public class ProductBase : NamedEntity
    {
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Cost { get; set; }
        public int AmountData { get; set; }





        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    
    }
}
