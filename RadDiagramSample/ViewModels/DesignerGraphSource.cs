using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;
using Telerik.Windows.Diagrams.Core;

namespace RadDiagramSample.ViewModels
{
    public class DesignerGraphSource:GraphSourceBase<ControlViewModel,ConnectionViewModel>
    {
        public void AddItem(ControlViewModel model)
        {
            this.AddNode(model);
        }
    }
}