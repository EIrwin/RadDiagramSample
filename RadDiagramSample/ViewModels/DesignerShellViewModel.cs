using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerShellViewModel:ViewModelBase
    {
        private readonly List<ControlViewModel> _controls;

        public DesignerShellViewModel()
        {
            _controls = new List<ControlViewModel>();
        }

        public void AddControl(ControlViewModel model)
        {
            if (_controls.All(p => p != model))
                _controls.Add(model);
            
        }
    }
}