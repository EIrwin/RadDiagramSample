using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerViewModel : ViewModelBase
    {

        private readonly ObservableCollection<ControlViewModel> _controls;
        private readonly ObservableCollection<ConnectionViewModel> _connections;

        public DesignerViewModel()
        {
            _controls = new ObservableCollection<ControlViewModel>();
            _connections = new ObservableCollection<ConnectionViewModel>();
        }

        public void AddControl(ControlViewModel model)
        {
            _controls.Add(model);
        }

        public void RemoveControl(ControlViewModel model)
        {
            _controls.Remove(model);
        }

        public void AddConnection(ConnectionViewModel model)
        {
            _connections.Add(model);
        }

        public void RemoveConnection(ConnectionViewModel model)
        {
            _connections.Remove(model);
        }
        
        public void Save()
        {
            
        }

        public void Generate()
        {
            
        }
    }
}