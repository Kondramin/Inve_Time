using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Inve_Time.Services
{
    class AutoChoseCategoryProductService
    {
        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<HelpCategorySearch> _HelpCategorySearchRepository;

        
        
        public AutoChoseCategoryProductService(IRepository<Product> ProductRepository, IRepository<HelpCategorySearch> HelpCategorySearchRepository)
        {
            _ProductRepository = ProductRepository;
            _HelpCategorySearchRepository = HelpCategorySearchRepository;
        }
        
        
        
        public void IdentifyCategory()
        {
            var prodNullCategory = _ProductRepository.Items.Where(p => EF.Functions.Like(p.Category.Name, null));
            var helpCategorySearch = _HelpCategorySearchRepository.Items;
            foreach (var cat in helpCategorySearch)
            {
                string SQLcat = $"%{cat.Name}%";
                var selectedProdNullCategory = prodNullCategory.Where(p => EF.Functions.Like(p.Name, SQLcat));
                foreach (var product in selectedProdNullCategory)
                {
                    product.Category = cat.Category;
                    _ProductRepository.Update(product);
                }
            }
        }
        
        
        public async Task IdentifyCategoryAsync()
        {
            var prodNullCategory = _ProductRepository.Items.Where(p => EF.Functions.Like(p.Category.Name, null));
            var helpCategorySearch = _HelpCategorySearchRepository.Items;
            foreach (var cat in helpCategorySearch)
            {
                string SQLcat = $"%{cat.Name}%";
                var selectedProdNullCategory = prodNullCategory.Where(p => EF.Functions.Like(p.Name, SQLcat));
                foreach (var product in selectedProdNullCategory)
                {
                    product.Category = cat.Category;
                    await _ProductRepository.UpdateAsync(product);
                }
            }
        }



    }
}
