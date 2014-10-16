using System;
using System.Linq;
using System.Windows.Controls;
using RadDiagramSample.ViewModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace RadDiagramSample.Views
{
    /// <summary>
    /// Interaction logic for Designer.xaml
    /// </summary>
    public partial class Designer : RadDiagram
    {
        private ControlViewModel _viewModel;
        public ControlViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                DataContext = _viewModel;
                _viewModel = value;
            }
        }

        public Designer()
        {

            InitializeComponent();
        }

        private void Diagram_ConnectionManipulationCompleted(object sender, ManipulationRoutedEventArgs e)
        {
            if (e.Shape == null)
            {
                
                if (Diagram.Connections.Contains(e.ManipulationPoint.Connection))
                {
                    Diagram.RemoveConnection(e.ManipulationPoint.Connection);
                    ViewModel.RemoveConnection(e.Connection.Id);
                }

                e.Handled = true;
            }
            else
            {
                if (!Diagram.Connections.Any(p => p.Target == e.Connection.Target && p.Source == e.Connection.Source))
                {
                    //Check if connection already exists in 
                    ConnectionViewModel model = new ConnectionViewModel()
                        {
                            Id = e.Connection.Id,
                            Source =
                                ((ControlView) e.ManipulationPoint.Connection.Source).DataContext as ControlViewModel,
                            SourceCapType = CapType.None,
                            Target = ((ControlView) e.Shape).DataContext as ControlViewModel,
                            TargetCapType = CapType.Arrow1,
                            Position = e.ManipulationPoint.Position,
                        };

                    ViewModel.AddConnection(model);
                }
            }
        }

        private void Diagram_PreviewDrop(object sender, System.Windows.DragEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)e.Data.GetData(e.Data.GetFormats()[0]);
            ListBoxViewModel listBoxViewModel = (ListBoxViewModel)listBoxItem.DataContext;

            //Generate the ViewModel based on the business
            //object that the ListBoxViewModel references
            ControlViewModel model = ControlViewModelFactory.Create(listBoxViewModel.ComponentType);
            model.Position = e.GetPosition(Diagram);
            ViewModel.AddControl(model);

            //Generate the View based on the business
            //object that the ListBoxViewModel references
            ControlView view = ControlViewFactory.Create(listBoxViewModel.ViewType);
            view.DataContext = model; 
            Diagram.AddShape(view);
        }
    }
}
