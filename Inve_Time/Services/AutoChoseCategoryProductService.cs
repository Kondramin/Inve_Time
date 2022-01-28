using Inve_Time.Services.ServiceInterfaces;
using System.Threading.Tasks;

namespace Inve_Time.Services
{
    internal class AutoChoseCategoryProductService : IAutoChoseCategoryProductService
    {
        //private readonly IRepository<ProductInfo> _ProductBaseRepository;
        //private readonly IRepository<ProductInvented> _ProductInventedRepossitory;
        //private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;
        //private readonly InveTimeDB _Db;

        public AutoChoseCategoryProductService(
            //IRepository<ProductInfo> ProductRepository,
            //IRepository<ProductInvented> ProductInventedRepossitory,
            //IRepository<CategorySearchWord> CategorySearchWordRepository,
            //InveTimeDB db
            )
        {
            //_ProductBaseRepository = ProductRepository;
            //_ProductInventedRepossitory = ProductInventedRepossitory;
            //_CategorySearchWordRepository = CategorySearchWordRepository;
            //_Db = db;
        }



        public void IdentifyCategory()
        {
            //_ProductBaseRepository.AutoSaveChanges = false;
            //_ProductInventedRepossitory.AutoSaveChanges = false;


            //foreach (var nullCategory in _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null)))
            //{
            //    if (_ProductBaseRepository.Items.Select(p => p.Name).Contains(nullCategory.Name))
            //    {
            //        nullCategory.Category = _ProductBaseRepository.Items.FirstOrDefault(p => p.Name == nullCategory.Name).Category;
            //        _ProductInventedRepossitory.Update(nullCategory);
            //    }
            //}


          //  var prodStillNullCategory = _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null));


            //if (!(prodStillNullCategory.Any())) return;


            //foreach (var search in _CategorySearchWordRepository.Items)
            //{
            //    string SQLsearch = $"%{search.Name}%";

            //    var selectedProdStillNullCategory = prodStillNullCategory.Where(p => EF.Functions.Like(p.Name, SQLsearch));

            //    foreach (var prod in selectedProdStillNullCategory)
            //    {
            //        prod.Category = search.Category;
            //        _ProductInventedRepossitory.Update(prod);
            //        _ProductBaseRepository.Add(new ProductInfo()
            //        {
            //            Name = prod.Name,
            //            Barcode = prod.Barcode,
            //            VendorCode = prod.VendorCode,
            //            Cost = prod.Cost,
            //            Category = prod.Category
            //        });
            //    }
            //}

            //_Db.SaveChanges();
        }


        public async Task IdentifyCategoryAsync()
        {
            //_ProductBaseRepository.AutoSaveChanges = false;
            //_ProductInventedRepossitory.AutoSaveChanges = false;


            //foreach (var nullCategory in _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null)))
            //{
            //    if (_ProductBaseRepository.Items.Select(p => p.Name).Contains(nullCategory.Name))
            //    {
            //        nullCategory.Category = _ProductBaseRepository.Items.FirstOrDefault(p => p.Name == nullCategory.Name).Category;
            //        await _ProductInventedRepossitory.UpdateAsync(nullCategory);
            //    }
            //}


            //var prodStillNullCategory = _ProductInventedRepossitory.Items.Where(p => EF.Functions.Like(p.Category.Name, null));


            //if (!(prodStillNullCategory.Any())) return;


            //foreach (var search in _CategorySearchWordRepository.Items)
            //{
            //    string SQLsearch = $"%{search.Name}%";

            //    var selectedProdStillNullCategory = prodStillNullCategory.Where(p => EF.Functions.Like(p.Name, SQLsearch));

            //    foreach (var prod in selectedProdStillNullCategory)
            //    {
            //        prod.Category = search.Category;
            //        await _ProductInventedRepossitory.UpdateAsync(prod);
            //        await _ProductBaseRepository.AddAsync(new ProductInfo()
            //        {
            //            Name = prod.Name,
            //            Barcode = prod.Barcode,
            //            VendorCode = prod.VendorCode,
            //            Cost = prod.Cost,
            //            Category = prod.Category
            //        });
            //    }
            //}

            //await _Db.SaveChangesAsync();

        }
    }
}
