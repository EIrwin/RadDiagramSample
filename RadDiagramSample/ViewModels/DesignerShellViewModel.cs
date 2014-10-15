using System.Collections.Generic;
using System.Linq;
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

        public void AddDesigner(DesignerViewModel model)
        {
            if (_designers.All(p => p != model))
                _designers.Add(model);
            
        }
    }
}