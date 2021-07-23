using Inve_Time.DataBase.dll.Entities.Base;
using System.Collections.Generic;

namespace Inve_Time.DataBase.dll.Entities
{
    public class ProductInvented : NamedEntity
    {
        public int AmountFact { get; set; }

        public int AmountResult { get; set; }
        public bool Peresort { get; set; } = false;



        public ICollection<CurrentInventarisation> CurrentInventarisations { get; set; }
    }
}
