using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class ProductInvented : Entity
    {
        public int AmountData { get; set; }
        public int AmountFact { get; set; }

        /// <summary>result=AmountData-AmountFact</summary>
        public int AmountResult { get; set; }
        public bool Re_Grading { get; set; }


        public int? ProductInfoId { get; set; }
        public ProductInfo ProductInfo { get; set; }


        public ICollection<InventarisationEvent> InventarisationEvents { get; set; }
    }
}
