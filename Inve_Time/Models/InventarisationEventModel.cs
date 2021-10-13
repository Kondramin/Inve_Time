using Inve_Time.DataBase.dll.Entities;
using System.Collections.ObjectModel;

namespace Inve_Time.Models
{
    internal class InventarisationEventModel : InventarisationEvent
    {
        public InventarisationEventModel() { }

        public InventarisationEventModel(InventarisationEvent inventarisationEvent)
        {
            Id = inventarisationEvent.Id;
            DateOfEvent = inventarisationEvent.DateOfEvent;
            EmployeeId = inventarisationEvent.EmployeeId;
            ResponsibleForEvent = inventarisationEvent.ResponsibleForEvent;
            ProductInventeds = inventarisationEvent.ProductInventeds;
            DistributeProduct();
        }

        private void DistributeProduct()
        {
            if (ProductInventeds is null) return;
            foreach(var product in ProductInventeds)
            {
                if (product.Re_Grading)
                {
                    Re_gradingAmountObsColl.Add(product);
                    break;
                }
                if (product.AmountResult > 0)
                {
                    ShortageAmountObsColl.Add(product);
                    break;
                }
                if (product.AmountResult < 0)
                {
                    OverAmountObsColl.Add(product);
                    break;
                }
            }
        }

        public ObservableCollection<ProductInvented> Re_gradingAmountObsColl { get; set; } = new();
        public ObservableCollection<ProductInvented> OverAmountObsColl { get; set; } = new();
        public ObservableCollection<ProductInvented> ShortageAmountObsColl { get; set; } = new();

        public decimal? ShortagePrice
        {
            get
            {
                decimal? cost = 0;
                foreach(var item in ShortageAmountObsColl)
                {
                    cost += item.Cost;
                }
                return cost;
            }
        }
    }
}
