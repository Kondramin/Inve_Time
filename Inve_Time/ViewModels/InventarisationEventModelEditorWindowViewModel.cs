using Inve_Time.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inve_Time.ViewModels
{
    internal class InventarisationEventModelEditorWindowViewModel : ViewModel
    {
        public InventarisationEventModelEditorWindowViewModel()
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Ctor not for Runtime!!!");
        }
    }
}
