using Inve_Time.ViewModels.Base;

namespace Inve_Time.ViewModels
{
    class MainWindowViewModel : ViewModel
    {



        #region string MainWindow Title  = "Inve_Time"

        private string _Title = "Inve_Time";
        /// <summary>MainWindow Title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion



    }
}
