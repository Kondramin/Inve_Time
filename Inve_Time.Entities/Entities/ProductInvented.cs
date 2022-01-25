using Inve_Time.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.Entities.Entities
{
    public class ProductInvented : Entity
    {
        public int AmountData { get; set; }
        public int AmountFact { get; set; }

        
        
        /// <summary>Result = AmountData - AmountFact</summary>
        public int AmountResult { get; set; }
        public bool Re_Grading { get; set; }


        
        public int? ProductInfoId { get; set; }
        public Product ProductInfo { get; set; }



        public ICollection<InventoryEvent> InventoryEvents { get; set; }
    }
}
