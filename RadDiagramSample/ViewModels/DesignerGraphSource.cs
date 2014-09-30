using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

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