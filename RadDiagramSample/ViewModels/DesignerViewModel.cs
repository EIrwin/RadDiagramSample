using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerViewModel : ViewModelBase
    {

        private IDictionary<string,ControlViewModel> _controls;
        private IDictionary<string,ConnectionViewModel> _connections;

        public DesignerViewModel()
        {
            _controls = new Dictionary<string, ControlViewModel>();
            _connections = new Dictionary<string, ConnectionViewModel>();
        }

        public void AddControl(ControlViewModel model)
        {
            _controls.Add(model.Id.ToString(), model);
        }

        public void RemoveControl(ControlViewModel model)
        {
            _controls.Remove(model.Id.ToString());
        }

        public void AddConnection(ConnectionViewModel model)
        {
            _connections.Add(model.Id, model);
        }

        public void RemoveConnection(string id)
        {
            _connections.Remove(id);
        }
        
        public void Save()
        {
            
        }

        public void Generate()
        {
            
        }
    }
}