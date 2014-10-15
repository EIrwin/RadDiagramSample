using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerShellViewModel:ViewModelBase
    {
        private List<DesignerViewModel> _designers;

        public DesignerShellViewModel()
        {
            _designers = new List<DesignerViewModel>();
        }
    }
}