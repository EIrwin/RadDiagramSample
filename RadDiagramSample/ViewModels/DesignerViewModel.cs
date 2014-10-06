using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerViewModel : ViewModelBase
    {
        private ObservableCollection<ControlViewModel> Controls { get; set; }
        private ObservableCollection<ConnectionViewModel> Connections { get; set; }

        public DesignerViewModel()
        {
            Controls = new ObservableCollection<ControlViewModel>();
            Connections = new ObservableCollection<ConnectionViewModel>();
        }

        public void AddControl(ControlViewModel model)
        {
            Controls.Add(model);
        }

        public void AddConnection(ConnectionViewModel model)
        {
            Connections.Add(model);
        }
    }
}