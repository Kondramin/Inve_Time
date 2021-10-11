using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class ProductInvented : ProductBase
    {
        public int AmountData { get; set; }
        public int AmountFact { get; set; }

        public int AmountResult { get; set; }
        public bool Re_Grading { get; set; } = false;


        public int? ProductBaseId { get; set; }
        public ProductBase ProductBase { get; set; }


        public ICollection<InventarisationEvent> InventarisationEvents { get; set; }
    }
}
