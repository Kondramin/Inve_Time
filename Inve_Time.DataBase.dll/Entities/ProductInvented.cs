using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class ProductInvented : ProductBase
    {
        public int AmountData { get; set; }
        public int AmountFact { get; set; }

        public int AmountResult { get; set; }
        public bool Peresort { get; set; } = false;



        public int? ProductBaseId { get; set; }
        public ProductBase ProductBase { get; set; }

        public ICollection<CurrentInventarisation> CurrentInventarisations { get; set; }
    }
}
