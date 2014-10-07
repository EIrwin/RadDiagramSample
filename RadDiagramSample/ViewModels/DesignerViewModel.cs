using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace RadDiagramSample.ViewModels
{
    public class DesignerViewModel : ViewModelBase<ControlViewModel,ConnectionViewModel>
    {
        public override void AddControl(ControlViewModel model)
        {
            base.Controls.Add(model);
        }

        public override void AddConnection(ConnectionViewModel model)
        {
            base.Connections.Add(model);
        }
    }

    public abstract class ViewModelBase<TControl,TConnection>:ViewModelBase where TControl: ControlViewModel 
                                                                            where TConnection:ConnectionViewModel
    {
        protected readonly ObservableCollection<TControl> Controls;
        protected readonly ObservableCollection<TConnection> Connections;

        protected ViewModelBase()
        {
            Controls = new ObservableCollection<TControl>();
            Connections = new ObservableCollection<TConnection>();
        }

        public abstract void AddControl(TControl model);
        public abstract void AddConnection(TConnection model);
    }
}