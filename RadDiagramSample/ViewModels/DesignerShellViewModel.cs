using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerShellViewModel:ViewModelBase
    {
        private readonly List<ControlViewModel> _controls;
        public Stack<ControlViewModel> ControlStack { get; set; }
        public DesignerShellViewModel()
        {
            _controls = new List<ControlViewModel>();
            ControlStack = new Stack<ControlViewModel>();
        }

        public void AddControl(ControlViewModel model)
        {
            if (_controls.All(p => p != model))
                _controls.Add(model);

            ControlStack.Push(model);
        }

        public void RemoveControl(ControlViewModel model)
        {
            if (_controls.Any(p => p.Id == model.Id))
                _controls.Remove(model);

        }
    }
}