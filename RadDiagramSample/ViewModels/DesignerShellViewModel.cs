using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerShellViewModel:ViewModelBase
    {
        public Stack<ControlViewModel> ControlStack { get; set; }

        public DesignerShellViewModel()
        {
            ControlStack = new Stack<ControlViewModel>();
        }

        //For now we are going to access the ControlStack
        //through the auto-property implementation, but
        //it would be better to access it in the future
        //through methods
    }
}