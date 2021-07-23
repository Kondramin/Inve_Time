using Inve_Time.DataBase.dll.Context;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Inve_Time.Services
{
    internal class AutoChoseCategoryProductService : IAutoChoseCategoryProductService
    {
        private readonly IRepository<ProductBase> _ProductBaseRepository;
        private readonly IRepository<ProductInvented> _ProductInventedRepossitory;
        private readonly IRepository<HelpCategorySearch> _HelpCategorySearchRepository;
        private readonly InveTimeDB _Db;

        public AutoChoseCategoryProductService(
            IRepository<ProductBase> ProductRepository,
            IRepository<ProductInvented> ProductInventedRepossitory,
            IRepository<HelpCategorySearch> HelpCategorySearchRepository,
            InveTimeDB db
            )
        {
            _ProductBaseRepository = ProductRepository;
            _ProductInventedRepossitory = ProductInventedRepossitory;
            _HelpCategorySearchRepository = HelpCategorySearchRepository;
            _Db = db;
        }



        public void IdentifyCategory()
        {
            _ProductBaseRepository.AutoSaveChanges = false;
            _ProductInventedRepossitory.AutoSaveChanges = false;


            foreach (var nullCategory in _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null)))
            {
                if (_ProductBaseRepository.Items.Select(p => p.Name).Contains(nullCategory.Name))
                {
                    nullCategory.Category = _ProductBaseRepository.Items.FirstOrDefault(p => p.Name == nullCategory.Name).Category;
                    _ProductInventedRepossitory.Update(nullCategory);
                }
            }


            var prodStillNullCategory = _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null));


            if (!(prodStillNullCategory.Any())) return;


            foreach (var search in _HelpCategorySearchRepository.Items)
            {
                string SQLsearch = $"%{search.Name}%";

                var selectedProdStillNullCategory = prodStillNullCategory.Where(p => EF.Functions.Like(p.Name, SQLsearch));

                foreach (var prod in selectedProdStillNullCategory)
                {
                    prod.Category = search.Category;
                    _ProductInventedRepossitory.Update(prod);
                    _ProductBaseRepository.Add(new ProductBase()
                    {
                        Name = prod.Name,
                        Barcode = prod.Barcode,
                        VendorCode = prod.VendorCode,
                        Cost = prod.Cost,
                        Category = prod.Category
                    });
                }
            }

            _Db.SaveChanges();
        }


        public async Task IdentifyCategoryAsync()
        {
            _ProductBaseRepository.AutoSaveChanges = false;
            _ProductInventedRepossitory.AutoSaveChanges = false;


            foreach (var nullCategory in _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null)))
            {
                if (_ProductBaseRepository.Items.Select(p => p.Name).Contains(nullCategory.Name))
                {
                    nullCategory.Category = _ProductBaseRepository.Items.FirstOrDefault(p => p.Name == nullCategory.Name).Category;
                    await _ProductInventedRepossitory.UpdateAsync(nullCategory);
                }
            }


            var prodStillNullCategory = _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null));


            if (!(prodStillNullCategory.Any())) return;


            foreach (var search in _HelpCategorySearchRepository.Items)
            {
                string SQLsearch = $"%{search.Name}%";

                var selectedProdStillNullCategory = prodStillNullCategory.Where(p => EF.Functions.Like(p.Name, SQLsearch));

                foreach (var prod in selectedProdStillNullCategory)
                {
                    prod.Category = search.Category;
                    await _ProductInventedRepossitory.UpdateAsync(prod);
                    await _ProductBaseRepository.AddAsync(new ProductBase()
                    {
                        Name = prod.Name,
                        Barcode = prod.Barcode,
                        VendorCode = prod.VendorCode,
                        Cost = prod.Cost,
                        Category = prod.Category
                    });
                }
            }

            await _Db.SaveChangesAsync();

        }
    }
}
