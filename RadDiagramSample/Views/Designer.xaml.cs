using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RadDiagramSample.Events;
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
                
                if (Diagram.Connections.Contains(e.Connection))
                {
                    Diagram.RemoveConnection(e.Connection);
                    ConnectionViewModel model = (ConnectionViewModel) ((RadDiagramConnection) e.Connection).DataContext;
                    ViewModel.Connections.Remove(model);
                }
            }
            else
            {
                if (!Diagram.Connections.Any(p => p.Target == e.Connection.Target && p.Source == e.Connection.Source))
                {
                    ConnectionViewModel model = new ConnectionViewModel()
                        {
                            Id = e.Connection.Id,

                            //Initialize the model with the 'Source'
                            //information we can use it at a later time
                            Source =((ControlView) e.Connection.Source).DataContext as ControlViewModel,
                            SourceCapType = CapType.None,
                            SourceConnector = e.Connection.SourceConnectorResult,
                            SourceConnectorPosition = e.Connection.SourceConnectorPosition,
                            
                            //Initialize the model with the 'Target'
                            //information we can use it at a later time
                            Target = ((ControlView) e.Shape).DataContext as ControlViewModel,
                            TargetCapType = CapType.Arrow1,
                            TargetConnector = e.Connector,
                            TargetConnectorPosition = e.Connector.Name,
                        };

                    ViewModel.Connections.Add(model);
                    Diagram.AddConnection(e.Connection.Source, e.Shape,e.Connection.SourceConnectorPosition,e.Connector.Name);
                }
            }
            e.Handled = true;
        }

        private void Diagram_PreviewDrop(object sender, DragEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)e.Data.GetData(e.Data.GetFormats()[0]);
            ListBoxViewModel listBoxViewModel = (ListBoxViewModel)listBoxItem.DataContext;

            //Generate the ViewModel based on the business
            //object that the ListBoxViewModel references
            ControlViewModel model = ControlViewModelFactory.Create(listBoxViewModel.ComponentType);
            model.Position = e.GetPosition(Diagram);
            model.ViewType = listBoxViewModel.ViewType;
            ViewModel.Controls.Add(model);

            //Generate the View based on the business
            //object that the ListBoxViewModel references
            ControlView view = ControlViewFactory.Create(listBoxViewModel.ViewType);
            view.DataContext = model;
            view.PreviewMouseLeftButtonDown += Diagram_ControlClicked;
            Diagram.AddShape(view);
        }

        private void Diagram_ControlClicked(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount  == 2)
            {
                ControlView view = (ControlView) sender;
                ViewModel = view.DataContext as ControlViewModel;
                ControlClicked(sender, new ControlClickedEventArgs(view));
            }
        }

        public void Load(ControlViewModel model)
        {
            Diagram.ViewModel = model;

            List<ControlViewModel> controls = new List<ControlViewModel>();

            model.Connections.ForEach(conn =>
                {
                    ControlViewModel source = conn.Source;
                    ControlView sourceView = ControlViewFactory.Create(source.ViewType);
                    sourceView.DataContext = source;
                    sourceView.Position = source.Position;
                    sourceView.PreviewMouseLeftButtonDown += Diagram_ControlClicked;

                    ControlViewModel target = conn.Target;
                    ControlView targetView = ControlViewFactory.Create(target.ViewType);
                    targetView.DataContext = target;
                    targetView.Position = target.Position;
                    targetView.PreviewMouseLeftButtonDown += Diagram_ControlClicked;

                    if (!controls.Any(p => p.Id == source.Id))
                    {
                        controls.Add(source);
                        Diagram.AddShape(sourceView);
                    }

                    if (!controls.Any(p => p.Id == target.Id))
                    {
                        controls.Add(target);
                        Diagram.AddShape(targetView);
                    }

                    RadDiagramConnection connection = new RadDiagramConnection();
                    connection.DataContext = conn;
                    connection.Source = sourceView;
                    connection.SourceConnectorPosition = conn.SourceConnectorPosition;
                    connection.Target = targetView;
                    connection.TargetConnectorPosition = conn.TargetConnectorPosition;

                    Diagram.AddConnection(connection);
                });

            model.Controls.Where(p => !controls.Contains(p)).ForEach(c =>
                {
                    ControlView view = ControlViewFactory.Create(c.ViewType);
                    view.DataContext = c;
                    view.Position = c.Position;
                    view.PreviewMouseLeftButtonDown += Diagram_ControlClicked;
                    Diagram.AddShape(view);
                });
        }

        public EventHandler<ControlClickedEventArgs> ControlClicked { get; set; }
    }

    
}
