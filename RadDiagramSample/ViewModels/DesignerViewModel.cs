using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerViewModel : ViewModelBase
    {
        public DesignerGraphSource DesignerGraphSource { get; private set; }

        public DesignerViewModel()
        {
            DesignerGraphSource = new DesignerGraphSource();
        }

        public void AddControl(ControlViewModel model)
        {
            DesignerGraphSource.AddNode(model);
        }
    }
}