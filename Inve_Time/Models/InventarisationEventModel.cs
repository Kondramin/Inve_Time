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
            ResponsibleEmployee = inventarisationEvent.ResponsibleEmployee;
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
                    if (product.AmountResult > 0)
                    {
                        Re_gradingShortageAmountObsColl.Add(product);
                        break;
                    }
                    if (product.AmountResult < 0)
                    {
                        Re_gradingOverAmountObsColl.Add(product);
                        break;
                    }
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

        
        public ObservableCollection<ProductInvented> OverAmountObsColl { get; set; } = new();
        public ObservableCollection<ProductInvented> ShortageAmountObsColl { get; set; } = new();

        public ObservableCollection<ProductInvented> Re_gradingOverAmountObsColl { get; set; } = new();
        public ObservableCollection<ProductInvented> Re_gradingShortageAmountObsColl { get; set; } = new();

        
        public decimal? ShortagePrice
        {
            get
            {
                decimal? cost = 0;
                foreach (var item in ShortageAmountObsColl)
                {
                    cost += item.ProductInfo.Cost;
                }
                return cost;
            }
        }
    }
}
