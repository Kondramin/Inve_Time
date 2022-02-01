using Inve_Time.DataBase.Context;
using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Inve_Time.Services.Services
{
    internal class AutoChoseCategoryProductService : IAutoChoseCategoryProductService
    {
        private readonly IRepository<Product> _ProductRepository;
        private readonly IRepository<CategorySearchWord> _CategorySearchWordRepository;
        private readonly InveTimeDB _Db;

        public AutoChoseCategoryProductService(
            IRepository<Product> productRepository,
            IRepository<CategorySearchWord> categorySearchWordRepository,
            InveTimeDB db
            )
        {
            _ProductRepository = productRepository;
            _CategorySearchWordRepository = categorySearchWordRepository;
            _Db = db;
        }


        public void IdentifyCategory()
        {
            _ProductRepository.AutoSaveChanges = false;

            foreach(var productWithNullCategory in _ProductRepository.Items.Where(prod => (prod.Category == null) || (prod.Category.Name == null))) //TODO: Удалить при ненадобности. /*EF.Functions.Like(prod.Category.Name, null)*/
            {
                foreach (var categorySearchword in _CategorySearchWordRepository.Items)
                {
                    if (productWithNullCategory.Name.Contains(categorySearchword.Name))
                    {
                        productWithNullCategory.CategoryId = categorySearchword.CategoryId;
                        productWithNullCategory.Category = categorySearchword.Category;
                        break;
                    }
                }

                _ProductRepository.Update(productWithNullCategory);
            }
            _ProductRepository.AutoSaveChanges = true;
            _Db.SaveChanges();

        }

        public async Task IdentifyCategoryAsync()
        {
            _ProductRepository.AutoSaveChanges = false;

            foreach (var productWithNullCategory in _ProductRepository.Items.Where(prod => (prod.Category == null) || (prod.Category.Name == null))) //TODO: Удалить при ненадобности. /*EF.Functions.Like(prod.Category.Name, null)*/
            {
                foreach (var categorySearchword in _CategorySearchWordRepository.Items)
                {
                    if (productWithNullCategory.Name.Contains(categorySearchword.Name))
                    {
                        productWithNullCategory.CategoryId = categorySearchword.CategoryId;
                        productWithNullCategory.Category = categorySearchword.Category;
                        break;
                    }
                }

                await _ProductRepository.UpdateAsync(productWithNullCategory);
            }
            _ProductRepository.AutoSaveChanges = true;
            await _Db.SaveChangesAsync();
        }
    }
}
