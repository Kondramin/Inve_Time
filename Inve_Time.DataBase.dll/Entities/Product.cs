using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inve_Time.DataBase.dll.Entities
{
    public class Product : NamedEntity
    {
        public string Barcode { get; set; }
        public string VendorCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Cost { get; set; }
        public int AmountData { get; set; }
        public int AmountFact { get; set; }



        public int AmountResult { get; set; }
        public bool Peresort { get; set; } = false;



        public int? CategoryId { get; set; }
        public Category Category { get; set; }




        public List<CurrentInventarisation> CurrentInventarisations { get; set; }
    }
}
