using Inve_Time.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inve_Time.Entities.Entities
{
    public class Product : NamedEntity
    {
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }


        public ICollection<ProductInvented> ProductInventeds { get; set; }


        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
