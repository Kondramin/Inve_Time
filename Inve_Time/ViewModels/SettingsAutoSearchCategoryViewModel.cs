using Inve_Time.Commands.Base;
using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Inve_Time.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inve_Time.ViewModels
{
    class SettingsAutoSearchCategoryViewModel : ViewModel
    {
        //TODO:Refactoring!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private readonly IRepository<Category> _CategoryRepository;

        public ObservableCollection<Category> CategoryHelpSearchesr { get; } = new ObservableCollection<Category>();

        #region Commands

        #region Command CategoryHelpSearchesrCommand - Get category with help searchers data from database

        /// <summary>Get category with help searchers data from database</summary>
        private ICommand _CategoryHelpSearchesrCommand;


        /// <summary>Get category with help searchers data from database</summary>
        public ICommand CategoryHelpSearchesrCommand => _CategoryHelpSearchesrCommand
            ??= new LambdaCommandAsync(OnCategoryHelpSearchesrCommandExequted);

        /// <summary>Execution logic - Get category with help searchers data from database</summary>
        /// <param name="p"></param>
        public async Task OnCategoryHelpSearchesrCommandExequted(object p)
        {
            await DownloadHelpSearchresAsync();
        }

        #endregion

        private async Task DownloadHelpSearchresAsync()
        {

            var categoryHelpQuery = _CategoryRepository.Items.GroupBy(c => c.Name);

            CategoryHelpSearchesr.Clear();

            foreach (Category category in await categoryHelpQuery.ToArrayAsync())
            {
                CategoryHelpSearchesr.Add(category);
            }
        }



        #endregion

        public SettingsAutoSearchCategoryViewModel(IRepository<Category> CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }


    }
}
